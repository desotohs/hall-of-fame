const electron = require("electron");
const path = require("path");
const url = require("url");
const cd = require("./cd");

var mainWindow;

function createWindow () {
    mainWindow = new electron.BrowserWindow({
        "show": false
    });
    cd.init("desotohs/hall-of-fame", mainWindow, () => {
        mainWindow.loadURL(`file:///${__dirname}/build/index.html`);
        mainWindow.webContents.once("did-finish-load", () => {
            mainWindow.show();
            mainWindow.setKiosk(true);
        });
    });
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
