import $ from "jquery";

const credentials = {
    "apiKey": "AIzaSyCrcdggt1_dsYGVZ87QL-5DR-LxMqZ5Z7s",
    "clientId": "308885765565-6vtlqs5f4ek923jjf5vdemgq21idno1l.apps.googleusercontent.com",
    "discoveryDocs": [
        "https://www.googleapis.com/discovery/v1/apis/drive/v3/rest"
    ],
    "scope": [
        "https://www.googleapis.com/auth/drive",
        "https://www.googleapis.com/auth/drive.appdata",
        "https://www.googleapis.com/auth/drive.file",
        "https://www.googleapis.com/auth/drive.metadata"
    ].join(" ")
};

let loaded = false;

$(window).ready(() => {
    let script = document.createElement("script");
    script.async = true;
    script.src = "https://apis.google.com/js/api.js";
    let loaded = false;
    let onLoad = () => {
        if (!loaded) {
            loaded = true;
            window.gapi.load("client:auth2", () => {
                window.gapi.client.init(credentials).then(() => {
                    loaded = true;
                    $(window).trigger("fs.ready");
                });
            });
        }
    };
    script.addEventListener("load", onLoad);
    script.addEventListener("readystatechange", ev => {
        if (ev.readyState === "complete") {
            onLoad();
        }
    });
    document.head.appendChild(script);
});

export default function gapi(cb) {
    if (cb) {
        if (loaded) {
            cb(window.gapi);
        } else {
            $(window).on("fs.ready", () => cb(window.gapi));
        }
    } else {
        return loaded ? window.gapi : null;
    }
};
