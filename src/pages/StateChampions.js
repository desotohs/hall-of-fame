import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import "./StateChampions.css";

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="statechampions">
                <BackgroundVideo />
                <div className="controls">
                    <div className="control">
                        Scholars Bowl
                    </div>
                    <div className="control">
                        Soccer
                    </div>
                    <div className="control">
                        Football
                    </div>
                    <div className="control">
                        Volleyball
                    </div>
                    <div className="control">
                        Basketball
                    </div>
                    <div className="control">
                        Baseball
                    </div>
                    <div className="control">
                        Softball
                    </div>
                </div>
            </div>
        );
    }
}
