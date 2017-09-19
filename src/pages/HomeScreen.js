import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import "./HomeScreen.css";

export default class HomeScreen extends React.Component {
    render() {
        return (
            <div className="homescreen">
                <BackgroundVideo />
                <div className="container">
                        <div className="control">
                            State Champions
                        </div>
                        <div className="control">
                            State Champions
                        </div>
                        <div className="control">
                            Hall of Fame
                        </div>
                        <div className="control">
                            State Champions
                        </div>
                        <div className="control">
                            State Champions
                        </div>
                        <div className="control">
                            State Champions
                        </div>
                    </div>
                
            </div>
        );
    }
}
