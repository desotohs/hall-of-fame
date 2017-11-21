import React from "react";
import "./NavBar.css";
import Icon from "./components/Icon";
import { Link } from "react-router-dom";

export default class NavBar extends React.Component {
    constructor(props){
        super(props);
        this.goBack = this.goBack.bind(this);
    }

    render() {
        return (
            <div className="navbar">
                <div onClick={this.goBack}>
                    <Icon name="chevron_left" />
                </div>
                <div>
                    <Icon name="radio_button_unchecked" />
                </div>
                <div>
                    <Icon name="share" />
                </div>
            </div>
        );
    }
    
    goBack() {
        window.history.back();
    }
}
