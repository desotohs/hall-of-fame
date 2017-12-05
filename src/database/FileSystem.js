import $ from "jquery";
import gapi from "./GDrive";
import DataBase from "./DataBase";

const FolderMime = "application/vnd.google-apps.folder";
const StorageTimeout = (window.localStorage && localStorage.fileSystemTimeout) || 24 * 60 * 60 * 1000;
const DownloadTimeout = 10000;
let LogDownloads = (window.localStorage && localStorage.logDownloads === "true") ? n => console.log(`Running downloads: ${n}`) : () => {};
var running = 0;

$(window).on("database.upgrade", () => {
    DataBase.createObjectStore("fs-ls", {
        "keyPath": "id"
    });
    DataBase.createObjectStore("fs-cat", {
        "keyPath": "id"
    });
});

class FileContents {
    constructor(contents, mime) {
        this.contents = contents;
        this.mime = mime;
    }
}

class FileSystemEntry {
    constructor(id, name, path, type) {
        this.id = id;
        this.name = name;
        this.path = path;
        this.type = type;
    }

    isFolder() {
        return this.type === FolderMime;
    }

    cachedFunc(tbl, id, provider, transformer, callback) {
        if(running === 0) {
            $(window).trigger("fs.download.start");
        }
        $(window).trigger("fs.download.change");
        running++;
        LogDownloads(running);
        const now = new Date().getTime();
        const error = old => provider(res => {
            if (res) {
                if (DataBase.isConnected()) {
                    DataBase.transaction(tbl, "readwrite").objectStore(tbl).put({
                        "id": id,
                        "date": now,
                        "result": res
                    });
                }
                running--;
                LogDownloads(running);
                callback(res);
            } else {
                running--;
                LogDownloads(running);
                callback(old || []);
            }
            if (running === 0) {
                $(window).trigger("fs.download.end");
            }
            $(window).trigger("fs.download.change");
        });
        DataBase.waitForConnectionOrFailure(() => {
            if (DataBase.isConnected()) {
                let req = DataBase.transaction(tbl).objectStore(tbl).get(id);
                req.addEventListener("success", () => {
                    if (req.result) {
                        let data = req.result;
                        const res = transformer(data.result);
                        if (now < data.date + StorageTimeout) {
                            running--;
                            LogDownloads(running);
                            if (running === 0) {
                                $(window).trigger("fs.download.end");
                            }
                            $(window).trigger("fs.download.change");
                            callback(res);
                        } else {
                            error(res);
                        }
                    } else {
                        error();
                    }
                });
                req.addEventListener("error", error);
            } else {
                error();
            }
        });
    }

    ls(callback) {
        if (!this.isFolder()) {
            throw new TypeError("File system entry is not a folder");
        }
        this.cachedFunc("fs-ls", this.id, cb => gapi(gapi => gapi.client.drive.files.list({
            "q": `'${this.id}' in parents`
        }).then(res => {
            let files = res.result.files;
            if (files && files.length > 0) {
                cb(files.map(f => new FileSystemEntry(f.id, f.name, `${this.path}${f.name}${f.mimeType === FolderMime ? "/" : ""}`, f.mimeType)));
            } else {
                cb();
            }
        })), a => a.map(o => new FileSystemEntry(o.id, o.name, o.path, o.type)), callback);
    }

    resolvePath(path, callback) {
        let parts = path.split("/").filter(c => c.length > 0);
        let func = (i, dir) => {
            if (i < parts.length) {
                dir.ls(dirs => {
                    let subdir = dirs.find(d => d.name === parts[i]);
                    if (subdir) {
                        func(i + 1, subdir);
                    } else {
                        callback(null);
                    }
                });
            } else {
                callback(dir);
            }
        };
        func(0, this);
    }

    cat(mime, callback) {
        if (this.isFolder()) {
            throw new TypeError("File system entry is a folder");
        }
        if (!callback) {
            callback = mime;
            mime = null;
        }
        if (mime) {
            this.cachedFunc("fs-cat", `${this.id}-${mime}`, cb => gapi(gapi => gapi.client.drive.files.export({
                "fileId": this.id,
                "mimeType": mime
            }).then(res => cb(new FileContents(res.body, res.headers["Content-Type"])))), o => o, callback);
        } else {
            this.cachedFunc("fs-cat", this.id, cb => gapi(gapi => gapi.client.drive.files.get({
                "fileId": this.id,
                "alt": "media"
            }).then(res => cb(new FileContents(res.body, res.headers["Content-Type"])))), o => o, callback);
        }
    }
}

const FileSystem = new FileSystemEntry("0B7i9Z91xLt3RN1dsNVY5azBTc00", "/", "/", FolderMime);
FileSystem.FolderMime = FolderMime;
export default FileSystem;
window.FileSystem = FileSystem;

let iid = -1;
$(window).on("fs.download.start", () => {
    iid = -1;
});
$(window).on("fs.download.change", () => {
    if (iid >= 0) {
        clearTimeout(iid);
    }
    if (iid !== -2) {
        iid = setTimeout(() => {
            window.location.reload();
        }, DownloadTimeout);
    }
});
$(window).on("fs.download.end", () => {
    if (iid >= 0) {
        clearTimeout(iid);
        iid = -2;
    }
});

window.clearFile = (name, mime) => {
    FileSystem.resolvePath(name, file => {
        if (file) {
            DataBase.waitForConnectionOrFailure(() => {
                if (DataBase.isConnected()) {
                    let tbl = file.isFolder() ? "fs-ls" : "fs-cat";
                    let req = DataBase.transaction(tbl, "readwrite").objectStore(tbl).delete(mime ? `${file.id}-${mime}` : file.id);
                    req.addEventListener("success", () => console.log("File successfully deleted."));
                    req.addEventListener("error", () => console.error("Unable to delete file!"));
                }
            });
        } else {
            console.warn("File is not downloaded.");
        }
    });
};
