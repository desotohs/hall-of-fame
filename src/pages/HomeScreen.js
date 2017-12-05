import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from "react-router-dom";
import IconManager from "../database/IconManager";
import loadCSV from "../database/CSVFile";
import FloatingButtons from "../components/FloatingButtons";
import Header from "../Header";
import "./HomeScreen.css";

export default class HomeScreen extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "buttons": []
        };
        let icons = new IconManager(this);
        loadCSV("/Table of Contents", csv => {
            this.setState({
                "buttons": csv.toArray().map(row => {
                    let icon = row.get("Icon Name");
                    icons.get(icon);
                    return {
                        "url": row.get("Page URL"),
                        "name": row.get("Page Name"),
                        "icon": icon
                    };
                })
            });
        });
    }

    render() {
        return (
            <div className="homescreen">
                <Header pageTitle="De Soto Wildcats"/>
                <BackgroundVideo />
                <FloatingButtons className="buttons" margin={20}>
                    {this.state.buttons.map((btn, i) => (
                        <div key={`btn-${i}`}>
                            <Link to={btn.url}>
                                <img className="iconImage" src={this.icons[btn.icon]} alt={btn.name} />
                            </Link>
                        </div>
                    ))}
                </FloatingButtons>
            </div>
        );
    }
}
