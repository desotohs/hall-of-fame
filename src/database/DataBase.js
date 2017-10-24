import $ from "jquery";

let req = indexedDB.open("HallOfFame", 1);
let db;
req.addEventListener("success", ev => {
    db = ev.target.result;
    $(window).trigger("database.load");
});
req.addEventListener("upgradeneeded", ev => {
    db = ev.target.result;
    $(window).trigger("database.upgrade");
});

const DataBase = {
    "isConnected": () => !!db,
    "transaction": (tables, flags) => db.transaction(tables, flags),
    "createObjectStore": (name, props) => db.createObjectStore(name, props)
};

window.DataBase = DataBase;
export default DataBase;
