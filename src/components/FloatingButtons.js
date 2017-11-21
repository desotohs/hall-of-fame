import React from "react";
import "./FloatingButtons.css";

export default class FloatingButtons extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "size": 0,
            "columns": 1,
            "centeringMargin": 0,
            "centeringWidth": 0
        };
        this.handleResize = this.handleResize.bind(this);
    }

    recalculateSize(props) {
        let numBtns = React.Children.count(props.children);
        if (numBtns > 0) {
            let width = this.container.clientWidth;
            let height = this.container.clientHeight;
            let maxArea = width * height;
            let targetArea = maxArea / numBtns;
            let targetHeight = Math.sqrt(targetArea);
            let realHeight = height / Math.ceil(height / targetHeight);
            let maxPerRow = Math.floor(width / realHeight);
            let minRows = Math.ceil(numBtns / maxPerRow);
            let maxColumns = Math.ceil(numBtns / minRows);
            this.setState({
                "size": realHeight - 2 * props.margin,
                "columns": maxColumns,
                "centeringMargin": (width - maxColumns * realHeight) / 2,
                "centeringWidth": maxColumns * realHeight
            });
        }
    }

    handleResize() {
        this.recalculateSize(this.props);
    }

    componentWillReceiveProps(newProps) {
        this.recalculateSize(newProps);
    }

    componentDidMount() {
        window.addEventListener("resize", this.handleResize);
        this.recalculateSize(this.props);
    }

    componentWillUnmount() {
        window.removeEventListener("resize", this.handleResize);
    }

    render() {
        return (
            <div className={`floating-buttons ${this.props.className}`} ref={el => this.container = el}>
                <div className="centering-container" style={{
                    "marginLeft": this.state.centeringMargin,
                    "width": this.state.centeringWidth
                }}>
                    {React.Children.map(this.props.children, (btn, i) => (
                        <div key={`btn-${i}`} className="button" style={{
                            "width": this.state.size,
                            "height": this.state.size,
                            "margin": this.props.margin
                        }}>
                            {btn}
                        </div>
                    ))}
                </div>
            </div>
        );
    }
}
