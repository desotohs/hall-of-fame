import React from "react";
import "./Header.css";
import Icon from "./components/Icon";
import Modal from "./components/Modal";

export default class Header extends React.Component {

    render() {
        return (
            <div className="header backgrey">
                <h1 className="title foregreen">{this.props.pageTitle}</h1>
            </div>
        );
    }
}
