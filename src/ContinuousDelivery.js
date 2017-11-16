import React from "react";

export default class ContinuousDelivery extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "updating": false
        };
    }

    componentDidMount() {
        this.socket = new WebSocket("wss://dhs-hall-of-fame.herokuapp.com");
        this.socket.addEventListener("message", () => {
            console.log("Updating...");
            this.setState({
                "updating": true
            });
            if (window.electron) {
                window.electron.ipcRenderer.send("github-update");
            } else if (window.location.hostname !== "localhost") {
                window.location.reload();
            }
        });
    }

    componentWillUnmount() {
        this.socket.close();
    }

    render() {
        return this.state.updating ? (
            <div>
                Updating...
            </div>
        ) : <div />;
    }
}
