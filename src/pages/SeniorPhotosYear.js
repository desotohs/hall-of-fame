import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import "./SeniorPhotosYear.css";

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="seniorphotosyear">
                <h2 className="year"> {this.props.match.params.year} </h2>
                <BackgroundVideo />
            </div>
        );
    }
     
}
