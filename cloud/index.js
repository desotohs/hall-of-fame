const express = require("express");
const expressWs = require("express-ws");
const path = require("path");
const port = process.env.PORT || 5000;
const secretKey = process.env.SECRET_UPDATE_KEY;

let app = express();
expressWs(app);

let sockets = [];

app.get(`/${secretKey}`, (req, res) => {
    sockets.forEach(socket => {
        socket.send("Updated.");
    });
    res.send("Success.");
});

app.ws("/", (ws, req) => {
    let close = () => {
        console.log("Client disconnected.");
        sockets.splice(sockets.indexOf(ws), 1);
    };

    ws.on("close", close);
    ws.on("error", close);

    console.log("Client connected.");
    sockets.push(ws);
});

app.use((req, res) => {
    res.redirect("https://desotohs.github.io/hall-of-fame/");
});

app.listen(port, () => {
    console.log(`Listening on port ${port}.`);
});
