import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import icon from "../media/images/logo.png";
import "./HomeScreen.css";

export default class HomeScreen extends React.Component {
    render() {
        return (
            <div className="homescreen">
                <BackgroundVideo />
                <div className="container">
                        <div className="control">
                            <img className="iconImage" src={icon} alt="test" />
                        </div>
                        <div className="control">
                            <img className="iconImage" src={icon} alt="test" />
                        </div>
                        <div className="control">
                            <img className="iconImage" src={icon} alt="test" />

                        </div>
                        <div className="control">
                            <img className="iconImage" src={icon} alt="test" />

                        </div>
                        <div className="control">
                            <img className="iconImage" src={icon} alt="test" />

                        </div>
                        <div className="control">
                            <img className="iconImage" src={icon} alt="test" />
                        </div>
                    </div>
                
            </div>
        );
    }
}
