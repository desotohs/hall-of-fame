import React from "react";
import video from "../media/video/fullscreenvideo.mp4";
import "./HomeScreen.css";

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

export default class HomeScreen extends React.Component {
    render() {
        return (
            <div className="homescreen">
                <Video className="blur" />
                <Video />
                <div className="container">
                        <div className="control">
                            Hall of Fame
                        </div>
                        <div className="control">
                            State Champions
                        </div>
                        <div className="control">
                            All Time Records
                        </div>
                        <div className="control">
                            Individual Honors
                        </div>
                        <div className="control">
                            Team Database
                        </div>
                        <div className="control">
                            Senior Class Photos
                        </div>
                    </div>
                
            </div>
        );
    }
}
