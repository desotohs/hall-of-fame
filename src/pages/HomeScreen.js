import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from "react-router-dom";
import IconManager from "../database/IconManager";
import "./HomeScreen.css";

export default class HomeScreen extends React.Component {
    constructor(props) {
        super(props);
        new IconManager(this).get("DeSotoHS_PrimaryMark_ForWhiteBackgroundR", "testIcon");
    }

    render() {
        return (
            <div className="homescreen">
                <BackgroundVideo />
                <div className="container">
                        <div className="control">
                            <Link to="/hallOfFame">
                                <img className="iconImage" src={this.icons.testIcon} alt="Hall of Fame" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/stateChampions">
                                <img className="iconImage" src={this.icons.testIcon} alt="State Champions" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/allTimeRecords">
                                <img className="iconImage" src={this.icons.testIcon} alt="All Time Records" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/individualHonors">
                                <img className="iconImage" src={this.icons.testIcon} alt="Individual Honors" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/seniorPhotos">
                                <img className="iconImage" src={this.icons.testIcon} alt="Senior Photos" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/teams">
                                <img className="iconImage" src={this.icons.testIcon} alt="Teams" />
                            </Link>
                        </div>
                    </div>
                
            </div>
        );
    }
}
