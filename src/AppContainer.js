import React from "react";
import "./AppContainer.css";

export default class AppContainer extends React.Component {
    render() {
        return (
            <div className="app-container">
                <div className={AppContainer.isDisplay ? "app-container-display" : "app-container-website"}>
                    {this.props.children}
                </div>
            </div>
        );
    }
}

AppContainer.isDisplay = (window.localStorage && localStorage.simulateDisplay === "true") || !!window.electron;
