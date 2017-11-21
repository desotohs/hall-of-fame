import React from "react";
import "./FloatingButtons.css";

export default class FloatingButtons extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "size": 0,
            "columns": 1,
            "centeringMargin": 0
        };
        this.recalculateSize = this.recalculateSize.bind(this);
    }

    recalculateSize() {
        let width = this.container.clientWidth;
        let height = this.container.clientHeight;
        let maxArea = width * height;
        let numBtns = React.Children.count(this.props.children);
        let targetArea = maxArea / numBtns;
        let targetHeight = Math.sqrt(targetArea);
        let realHeight = height / Math.ceil(height / targetHeight);
        let maxPerRow = Math.floor(width / realHeight);
        let minRows = Math.ceil(numBtns / maxPerRow);
        let maxColumns = Math.ceil(numBtns / minRows);
        this.setState({
            "size": realHeight - 2 * this.props.margin,
            "columns": maxColumns,
            "centeringMargin": (width - maxColumns * realHeight) / 2,
            "centeringWidth": maxColumns * realHeight
        });
    }

    componentDidMount() {
        window.addEventListener("resize", this.recalculateSize);
        this.recalculateSize();
    }

    componentWillUnmount() {
        window.removeEventListener("resize", this.recalculateSize);
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
