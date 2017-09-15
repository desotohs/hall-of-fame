import $ from "jquery";

let credentials = {
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

let gapi;

function setupDataFolder(appDataFolderId) {
    console.log(`https://drive.google.com/drive/folders/${appDataFolderId}`);
}

function setupFolder() {
    let drive = gapi.client.drive;
    drive.files.list({
        "q": "'root' in parents and not trashed and name = 'Hall of Fame'",
        "fields": "files(id, isAppAuthorized)",
        "pageSize": 100
    }).then(res => {
        let files = res.result.files;
        if (files && files.length > 0) {
            for (var i = 0; i < files.length; ++i) {
                if (files[i].isAppAuthorized) {
                    setupDataFolder(files[i].id);
                    return;
                }
            }
        }
        drive.files.create({
            "resource": {
                "name": "Hall of Fame",
                "mimeType": "application/vnd.google-apps.folder",
                "parents": [
                    "root"
                ]
            },
            "fields": "id"
        }).then(res => {
            setupDataFolder(res.result.id);
        });
    });
}

$(window).ready(() => {
    let script = document.createElement("script");
    script.async = true;
    script.src = "https://apis.google.com/js/api.js";
    let loaded = false;
    let onLoad = () => {
        if (!loaded) {
            loaded = true;
            gapi = window.gapi;
            gapi.load("client:auth2", () => {
                gapi.client.init(credentials).then(() => {
                    let auth = gapi.auth2.getAuthInstance();
                    if (auth.isSignedIn.get()) {
                        setupFolder();
                    } else {
                        auth.signIn();
                    }
                    auth.isSignedIn.listen(isSignedIn => {
                        if (isSignedIn) {
                            setupFolder();
                        }
                    });
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

export default gapi;
