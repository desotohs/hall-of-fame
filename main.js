const childProcess = require("child_process");
const connect = require("connect");
const electron = require("electron");
const nodegit = require("nodegit");
const path = require("path");
const serveStatic = require("serve-static");
const url = require("url");

var mainWindow;

function createWindow () {
    mainWindow = new electron.BrowserWindow({
        "show": false,
        "width": 1920,
        "height": 1080,
        "webPreferences": {
            "webSecurity": false
        }
    });
    mainWindow.webContents.once("did-finish-load", () => {
        mainWindow.show();
        mainWindow.setKiosk(true);
    });
    mainWindow.loadURL("http://localhost:3000/index.html");
    mainWindow.on("closed", function () {
        mainWindow = null;
    });
}

electron.app.on("ready", createWindow);

electron.app.on("window-all-closed", function () {
    if (process.platform !== "darwin") {
        electron.app.quit();
    }
});

electron.app.on("activate", function () {
    if (mainWindow === null) {
        createWindow();
    }
});

electron.ipcMain.on("github-update", () => {
    childProcess.execFile(`${__dirname}/.reboot.sh`);
});

connect().use(serveStatic(`${__dirname}/build`)).listen(3000, () => {
    console.log("Internal webserver running on localhost:3000.");
});
