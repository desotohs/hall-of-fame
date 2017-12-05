import React from "react";
import BackgroundVideo from "../../components/BackgroundVideo";
import Header from "../../Header";
import "./Year.css";

export default class Year extends React.Component {
    render() {
        return (
            <div className="seniorphotosyear">
                <Header pageTitle={"DHS Class of " + this.props.match.params.year} />
                <BackgroundVideo />
            </div>
        );
    }
     
}
