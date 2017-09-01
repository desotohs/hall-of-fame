const electron = require("electron");
const childProcess = require("child_process");

module.exports.compile = (callback, error) => {
    let proc = childProcess.spawn(`${__dirname}/node_modules/.bin/react-scripts`, [ "build" ], {
        "cwd": __dirname,
        "stdio": "inherit"
    });
    proc.on("close", code => {
        if (code == 0) {
            callback();
        } else {
            error();
        }
    });
    proc.on("error", error);
};

module.exports.restart = () => {
    console.log("Restarting app...");
    childProcess.spawn(`${__dirname}/node_modules/.bin/electron`, [ __dirname ]);
    electron.app.quit();
};
