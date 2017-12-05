import React from "react";
import BackgroundVideo from "../../components/BackgroundVideo";
import IconManager from "../../database/IconManager";
import "./Club.css";
import Header from "../../Header";

export default class Club extends React.Component {
    constructor(props) {
        super(props);
        const icons = new IconManager(this);
        icons.get(doTitle(this.props.match.params.club), "icon");
    }

    render() {
        return (
            <div className="statechampionclub">
                <Header pageTitle={doTitle(this.props.match.params.club)} />
                <BackgroundVideo />
                <img className="iconImage" src={this.icons.icon} alt={doTitle(this.props.match.params.club)} />
            </div>
        );
    }
     
}

function doTitle(club){
    const words = club.split("-")
    var result = "";
    for(var i = 0; i < words.length; i++){
        result = result + words[i].charAt(0).toUpperCase() + words[i].slice(1) + " ";
    }
    result = result.substring(0,  result.length - 1);
    return result
}