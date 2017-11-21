import React from "react";
import "./Modal.css";

export default class Modal extends React.Component {
    constructor(props) {
        super(props);
        this.buttons = this.props.buttons || (
            <a className="modal-action modal-close btn-flat" onClick={this.props.onClose}>
                Ok
            </a>
        );
    }

    render() {
        return (
            <div>
                <div className="modal open">
                    <div className="modal-content">
                        <h4>{this.props.title}</h4>
                        {this.props.content}
                    </div>
                    <div className="modal-footer">
                        {this.buttons}
                    </div>
                </div>
                <div className="modal-overlay" onClick={this.props.onClose} />
            </div>
        );
    }
}
