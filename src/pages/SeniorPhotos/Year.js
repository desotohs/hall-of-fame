import React from "react";
import BackgroundVideo from "../../components/BackgroundVideo";
import "./Year.css";

export default class Year extends React.Component {
    render() {
        return (
            <div className="seniorphotosyear">
                <h2 className="foregreen year">DHS Class of {this.props.match.params.year} </h2>
                <BackgroundVideo />
            </div>
        );
    }
     
}
