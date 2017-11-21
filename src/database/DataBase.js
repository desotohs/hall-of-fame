import $ from "jquery";

let db;
let connecting = true;
if (window.indexedDB) {
    let req = indexedDB.open("HallOfFame", 1);
    req.addEventListener("success", ev => {
        db = ev.target.result;
        $(window).trigger("database.load");
    });
    req.addEventListener("upgradeneeded", ev => {
        db = ev.target.result;
        $(window).trigger("database.upgrade");
    });
    req.addEventListener("error", () => {
        connecting = false;
    });
    setTimeout(() => {
        connecting = false;
        $(window).trigger("database.load.timeout");
    }, 2000);
} else {
    connecting = false;
}

const DataBase = {
    "isConnected": () => !!db,
    "waitForConnectionOrFailure": cb => {
        if (DataBase.isConnected()) {
            cb();
        } else if (connecting) {
            let called = false;
            let cbOnce = () => {
                if (!called) {
                    called = true;
                    cb();
                }
            };
            $(window).on("database.load", cbOnce);
            $(window).on("database.load.timeout", cbOnce);
        } else {
            cb();
        }
    },
    "transaction": (tables, flags) => db.transaction(tables, flags),
    "createObjectStore": (name, props) => db.createObjectStore(name, props)
};

window.DataBase = DataBase;
export default DataBase;
