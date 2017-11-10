import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import "./SeniorPhotosYear.css";

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="seniorphotosyear">
                <h2 className="foregreen year">DHS Class of {this.props.match.params.year} </h2>
                <BackgroundVideo />
            </div>
        );
    }
     
}
