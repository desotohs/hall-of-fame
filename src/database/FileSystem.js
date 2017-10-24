import $ from "jquery";
import gapi from "./GDrive";
import DataBase from "./DataBase";

const FolderMime = "application/vnd.google-apps.folder";
const StorageTimeout = localStorage.fileSystemTimeout || 24 * 60 * 60 * 1000;

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
                callback(res);
            } else {
                callback(old || []);
            }
        });
        if (DataBase.isConnected()) {
            let req = DataBase.transaction(tbl).objectStore(tbl).get(id);
            req.addEventListener("success", () => {
                if (req.result) {
                    let data = req.result;
                    const res = transformer(data.result);
                    if (now < data.date + StorageTimeout) {
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
