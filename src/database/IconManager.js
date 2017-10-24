import FileSystem from "./FileSystem";
import loadingImage from "./failover/image-loading.png";
import errorImage from "./failover/image-error.png";

function findRequired(arr, predicate, error, success) {
    let match = arr.find(predicate);
    if (match) {
        success(match);
    } else {
        error();
    }
}

export default class IconManager {
    constructor(component) {
        this.component = component;
        this.component.icons = this.component.icons || {};
    }

    error(name, callback) {
        console.error(`Unable to find icon '${name}'!`);
        callback(errorImage);
    }

    get(name, callback) {
        if (!callback) {
            callback = name;
        }
        const cb = value => {
            if (typeof(callback) === "string") {
                this.component.icons[callback] = value;
                this.component.forceUpdate();
            } else {
                callback(value);
            }
        };
        cb(loadingImage);
        const error = this.error.bind(this, name, cb);
        FileSystem.ls(dirs =>
            findRequired(dirs,
                dir => dir.name === "Icons",
                error,
                dir => dir.ls(icons =>
                    findRequired(icons,
                        icon => icon.name.startsWith(`${name}.`),
                        error,
                        icon => icon.cat(file => cb(`data:${file.mime};base64,${btoa(file.contents)}`))
                    )
                )
            )
        );
    }
}
