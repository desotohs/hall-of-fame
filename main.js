const electron = require("electron");
const nodegit = require("nodegit");
const path = require("path");
const url = require("url");
const cd = require("./cd");
const compiler = require("./compiler");

var mainWindow;

function createWindow () {
    mainWindow = new electron.BrowserWindow({
        "show": false,
        "width": 1920,
        "height": 1080
    });
    let error = false;
    cd.init("desotohs/hall-of-fame", mainWindow, () => {
        let repo, ourRef, theirRef;
        nodegit.Repository.open(__dirname).then(_repo => {
            repo = _repo;
            return repo.fetchAll();
        }).then(() => {
            return repo.getReference("master");
        }).then(_ourRef => {
            ourRef = _ourRef.target();
            return repo.getReference("origin/master");
        }).then(_theirRef => {
            theirRef = _theirRef.target();
            return repo.mergeBranches("master", "origin/master");
        }).catch(() => {
            error = true;
        }).done(() => {
            if (error) {
                mainWindow.loadURL(`file:///${__dirname}/build/index.html`);
            } else if (!ourRef.equal(theirRef)) {
                compiler.compile(() => compiler.restart(), () => {
                    mainWindow.loadURL(`file:///${__dirname}/build/index.html`);
                });
            } else {
                mainWindow.loadURL(`file:///${__dirname}/build/index.html`);
            }
            mainWindow.webContents.once("did-finish-load", () => {
                mainWindow.show();
                mainWindow.setKiosk(true);
            });
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
