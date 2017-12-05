import React from "react";
import $ from "jquery";
import "./LoadingPage.css";

export default class LoadingPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "isLoading": true
        };
        this.handleDownloadStart = this.handleDownloadStart.bind(this);
        this.handleDownloadEnd = this.handleDownloadEnd.bind(this);
    }

    handleDownloadStart() {
        this.setState({
            "isLoading": true
        });
    }

    handleDownloadEnd() {
        this.setState({
            "isLoading": false
        });
    }

    componentDidMount() {
        $(window).on("fs.download.start", this.handleDownloadStart)
                 .on("fs.download.end", this.handleDownloadEnd);
    }

    componentWillUnmount() {
        $(window).unbind("fs.download.start", this.handleDownloadStart)
                 .unbind("fs.download.end", this.handleDownloadEnd);
    }

    render() {
        return (
            <div className={`loading-page ${this.state.isLoading ? "active" : ""}`}>
                <br /><br /><br /><br />
                <div className="center">
                    <div className="preloader-wrapper big active">
                        <div className="spinner-layer spinner-blue-only">
                            <div className="circle-clipper left">
                                <div className="circle" />
                            </div>
                            <div className="gap-patch">
                                <div className="circle" />
                            </div>
                            <div className="circle-clipper right">
                                <div className="circle" />
                            </div>
                        </div>
                    </div>
                </div>
                <h1 className="center">
                    Loading...
                </h1>
                <h2 className="center">
                    Downloading new content.
                </h2>
            </div>
        );
    }
}
