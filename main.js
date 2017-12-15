const childProcess = require("child_process");
const electron = require("electron");
const nodegit = require("nodegit");
const path = require("path");
const url = require("url");
require("./proxy");

var mainWindow;

function createWindow () {
    mainWindow = new electron.BrowserWindow({
        //"show": false,
        "width": 1920,
        "height": 1080,
        "webPreferences": {
            "webSecurity": false
        }
    });
    mainWindow.toggleDevTools();
    mainWindow.webContents.once("did-finish-load", () => {
        //mainWindow.show();
        //mainWindow.setKiosk(true);
    });
    setTimeout(() => mainWindow.loadURL("http://kpirankings.wixsite.com:3000/dhswildcats"), 1000);
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
