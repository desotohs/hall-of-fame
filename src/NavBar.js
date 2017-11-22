import React from "react";
import "./NavBar.css";
import Icon from "./components/Icon";
import { Link } from "react-router-dom";
import Modal from "./components/Modal";
import QRCode from "./components/QRCode";

export default class NavBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "share": false
        };
        this.showShareView = this.showShareView.bind(this);
        this.hideShareView = this.hideShareView.bind(this);
    }

    showShareView() {
        this.setState({
            "share": true
        });
    }
    
    hideShareView() {
        this.setState({
            "share": false
        });
    }

    render() {
        let url;
        if (window.location.host === "desotohs.github.io") {
            url = window.location.href;
        } else {
            url = `https://desotohs.github.io/hall-of-fame${window.location.pathname}`;
        }
        return (
            <div>
                {this.state.share && (
                    <Modal title="Share Page" content={(
                        <div className="navbar-share">
                            <QRCode className="qr" text={url} />
                            <p>
                                {url}
                            </p>
                        </div>
                    )} onClose={this.hideShareView} />
                )}
                <div className="navbar">
                    <div onClick={window.history.back.bind(window.history)}>
                        <Icon name="chevron_left" />
                    </div>
                    <div>
                        <Link to={window.location.host === "desotohs.github.io" ? "/hall-of-fame/" : "/"}>
                            <Icon name="radio_button_unchecked" />
                        </Link>
                    </div>
                    <div onClick={this.showShareView}>
                        <Icon name="share" />
                    </div>
                </div>
            </div>
        );
    }
}
