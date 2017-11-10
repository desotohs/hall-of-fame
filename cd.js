const childProcess = require("child_process");
const electron = require("electron");
const https = require("https");
const WebSocket = require("ws");

module.exports.init = (repo, window, callback) => {
    window.loadURL("https://github.com/login");
    let wait = () => window.webContents.once("did-finish-load", () => {
        if (window.getURL() == "https://github.com/login") {
            window.show();
            window.setKiosk(true);
            wait();
        } else {
            electron.ipcMain.once("github-cd", (ev, webSocketUrl, userId) => {
                callback();
                https.get({
                    "protocol": "https:",
                    "host": "api.github.com",
                    "path": `/repos/${repo}`,
                    "headers": {
                        "User-Agent": "DHS Hall of Fame Display (https://github.com/desotohs/hall-of-fame)"
                    }
                }, res => {
                    res.setEncoding("utf8");
                    let raw = "";
                    res.on("data", chunk => raw += chunk);
                    res.on("end", () => {
                        let json = JSON.parse(raw);
                        let repoId = json.id;
                        let ws = new WebSocket(webSocketUrl);
                        ws.on("open", () => {
                            ws.send(`subscribe:repo:${repoId}:post-receive:${userId}`);
                            console.log("Listening for code changes...");
                        });
                        ws.on("message", data => {
                            json = JSON.parse(data);
                            console.log(json[1].reason);
                            electron.ipcMain.emit("github-cd-start");
                            childProcess.execFile(`${__dirname}/.reboot.sh`);
                        });
                    });
                });
            });
            window.webContents.executeJavaScript("require('electron').ipcRenderer.send('github-cd', document.querySelector('link[rel=web-socket]').href, document.querySelector('meta[name=octolytics-actor-id]').content)");
        }
    });
    wait();
};
