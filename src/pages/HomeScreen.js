import React from "react";
import video from "../media/video/fullscreenvideo.mp4";
import "./HomeScreen.css";


export default class HomeScreen extends React.Component {
    componentDidMount() {
        this.video.play();
    }

    render() {
        return (
            <div className="homescreen">
                <video loop ref={el => this.video = el}>
                    <source src={video} type="video/webm"/>
                </video>
            </div>
        );
    }
}
