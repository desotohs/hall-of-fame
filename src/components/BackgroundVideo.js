import React from "react";
import AppContainer from "../AppContainer";
import VideoManager from "../database/VideoManager";
import "./BackgroundVideo.css";

export default class BackgroundVideo extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "width": 0,
            "height": 0
        };
        this.manager = new VideoManager(this);
        this.recalculateSize = this.recalculateSize.bind(this);
    }

    recalculateSize() {
        this.setState({
            "width": AppContainer.isDisplay ? document.body.clientHeight : document.body.clientWidth,
            "height": AppContainer.isDisplay ? document.body.clientWidth : document.body.clientHeight
        });
    }

    componentDidMount() {
        this.manager.get(video => {
            this.videoFile = video;
            this.forceUpdate(() => this.video.play());
        });
        this.ctx = this.canvas.getContext("2d");
        this.video.addEventListener("play", () => {
            let videoAspect = 1920 / 1080;
            var renderedFrames = 0;
            this.iid = setInterval(() => {
                if (this.video) {
                    if (this.video.ended) {
                        this.manager.get(video => {
                            this.videoFile = video;
                            this.forceUpdate(() => this.video.play());
                        });
                    } else {
                        let x, y, width, height;
                        if (videoAspect > this.canvas.width / this.canvas.height) {
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
        window.addEventListener("resize", this.recalculateSize);
        this.recalculateSize();
    }

    componentWillUnmount() {
        clearInterval(this.iid);
        if (localStorage.debugVideoFPS) {
            clearInterval(this.iid2);
        }
        window.removeEventListener("resize", this.recalculateSize);
    }

    render() {
        return (
            <div className="background-video">
                <canvas width={this.state.width} height={this.state.height} ref={el => this.canvas = el} />
                <video src={this.videoFile} muted ref={el => this.video = el} />
            </div>
        );
    }
}
