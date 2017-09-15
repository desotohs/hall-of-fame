import React from "react";
import video from "../media/video/fullscreenvideo.mp4";
import "./StateChampions.css";

class Video extends React.Component {
    componentDidMount() {
        this.video.play();
    }

    render() {
        return (
            <video controls muted loop ref={el => this.video = el} className={this.props.className}>
                <source src={video} type="video/webm"/>
            </video>
        );
    }
}

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="statechampions">
                <Video className="blur" />
                <Video />
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
