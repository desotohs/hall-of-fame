import React from "react";
const electron = window.require ? require("electron") : null;

export default class CDNotification extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "compiling": false,
            "failed": false,
            "lastFailed": false
        };
        let on;
        if (electron) {
            on = electron.ipcRenderer.on.bind(electron.ipcRenderer);
        } else {
            window.eventListeners = window.eventListeners || {};
            on = (ev, callback) => window.eventListeners[ev] = callback;
        }
        on("github-cd-start", () => this.setState({
            "compiling": true,
            "failed": false
        }));
        on("github-cd-fail", () => {
            this.setState({
                "compiling": false,
                "failed": true,
                "lastFailed": true
            });
            setTimeout(() => this.setState({
                "failed": false
            }), 4000);
        });
    }

    render() {
        return (
            <div>
                {this.state.compiling && (
                    <div>
                        Compiling...
                    </div>
                )}
                {this.state.failed && (
                    <div>
                        Compilation Failed!
                    </div>
                )}
                {this.state.lastFailed && (
                    <div>
                        The last compilation attempt failed.
                    </div>
                )}
            </div>
        );
    }
}
