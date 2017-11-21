import React from "react";
import QRCode from "davidshimjs-qrcodejs";

export default class QRCodeView extends React.Component {
    componentDidMount() {
        this.qrcode = new QRCode(this.el, this.props);
    }

    componentWillUnmount() {
        this.qrcode.clear();
    }

    render() {
        return (
            <div ref={el => this.el = el} {...this.props} />
        );
    }
}
