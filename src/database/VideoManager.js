import FileSystem from "./FileSystem";
import loadingVideo from "./failover/video-loading.mp4";
import errorVideo from "./failover/video-error.mp4";

function findRequired(arr, predicate, error, success) {
    let match = arr.find(predicate);
    if (match) {
        success(match);
    } else {
        error();
    }
}

export default class VideoManager {
    constructor(component) {
        this.component = component;
        this.component.videos = this.component.videos || {};
    }

    error(callback) {
        console.error(`Unable to find video!`);
        callback(errorVideo);
    }

    get(callback) {
        const cb = value => {
            if (callback) {
                callback(value);
            } else {
                this.component.video = value;
                this.component.forceUpdate();
            }
        };
        cb(loadingVideo);
        const error = this.error.bind(this, cb);
        FileSystem.ls(dirs =>
            findRequired(dirs,
                dir => dir.name === "Videos",
                error,
                dir => dir.ls(videos => {
                    let video = videos[Math.floor(Math.random() * videos.length)];
                    video.cat(file => cb(`data:${file.mime};base64,${btoa(file.contents)}`));
                })
            )
        );
    }
}
