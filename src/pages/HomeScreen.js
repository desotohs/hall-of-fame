import React from "react";
import video from "../media/video/fullscreenvideo.mp4";
import "./HomeScreen.css";


export default class HomeScreen extends React.Component {
    render() {
        return (
            <div className="homescreen">
                <video controls autoplay loop>
                    <source src={video} type="video/webm"/>
                </video>
            </div>
        );
    }
}
