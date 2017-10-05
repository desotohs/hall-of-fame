import React from "react";
import video from "../media/video/fullscreenvideo.mp4";
import "./BackgroundVideo.css";

export default class BackgroundVideo extends React.Component {
    componentDidMount() {
        this.ctx = this.canvas.getContext("2d");
        this.video.addEventListener("play", () => {
            let videoAspect = 1920 / 1080;
            let documentAspect = this.canvas.width / this.canvas.height;
            var renderedFrames = 0;
            this.iid = setInterval(() => {
                if (this.video.isEnded) {
                    // TODO change the video
                } else {
                    let x, y, width, height;
                    if (videoAspect > documentAspect) {
                        width = this.canvas.width;
                        height = this.canvas.width / videoAspect;
                        x = 0;
                        y = (this.canvas.height - height) / 2;
                    } else {
                        width = this.canvas.height * videoAspect;
                        height = this.canvas.height;
                        x = (this.canvas.width - width) / 2;
                        y = 0;
                    }
                    this.ctx.filter = "blur(10px)";
                    this.ctx.drawImage(this.video, 0, 0, this.canvas.width, this.canvas.height);
                    this.ctx.filter = "none";
                    this.ctx.drawImage(this.video, x, y, width, height);
                    ++renderedFrames;
                }
            }, 0);
            if (localStorage.debugVideoFPS) {
                this.iid2 = setInterval(() => {
                    console.log(`Background video is running at ${renderedFrames * 1000 / localStorage.debugVideoFPS} FPS`);
                    renderedFrames = 0;
                }, localStorage.debugVideoFPS);
            }
        });
        this.video.play();
    }

    componentWillUnmount() {
        clearInterval(this.iid);
        if (localStorage.debugVideoFPS) {
            clearInterval(this.iid2);
        }
    }

    render() {
        return (
            <div className="background-video">
                <canvas width={document.body.clientWidth} height={document.body.clientHeight} ref={el => this.canvas = el} />
                <video src={video} loop muted ref={el => this.video = el} />
            </div>
        );
    }
}
