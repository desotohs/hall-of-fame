import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from "react-router-dom";
import IconManager from "../database/IconManager";
import FloatingButtons from "../components/FloatingButtons";
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
                <FloatingButtons className="buttons" margin={20}>
                    <div>
                        <Link to="/hallOfFame">
                            <img className="iconImage" src={this.icons.testIcon} alt="Hall of Fame" />
                        </Link>
                    </div>
                    <div>
                        <Link to="/stateChampions">
                            <img className="iconImage" src={this.icons.testIcon} alt="State Champions" />
                        </Link>
                    </div>
                    <div>
                        <Link to="/allTimeRecords">
                            <img className="iconImage" src={this.icons.testIcon} alt="All Time Records" />
                        </Link>
                    </div>
                    <div>
                        <Link to="/individualHonors">
                            <img className="iconImage" src={this.icons.testIcon} alt="Individual Honors" />
                        </Link>
                    </div>
                    <div>
                        <Link to="/seniorPhotos">
                            <img className="iconImage" src={this.icons.testIcon} alt="Senior Photos" />
                        </Link>
                    </div>
                    <div>
                        <Link to="/teams">
                            <img className="iconImage" src={this.icons.testIcon} alt="Teams" />
                        </Link>
                    </div>
                </FloatingButtons>
            </div>
        );
    }
}
