import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from 'react-router-dom'
import icon from "../media/images/logo.png";
import "./HomeScreen.css";

export default class HomeScreen extends React.Component {
    render() {
        return (
            <div className="homescreen">
                <BackgroundVideo />
                <div className="container">
                        <div className="control">
                            <Link to="/hallOfFame">
                                <img className="iconImage" src={icon} alt="Hall of Fame" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/stateChampions">
                                <img className="iconImage" src={icon} alt="State Champions" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/allTimeRecords">
                                <img className="iconImage" src={icon} alt="All Time Records" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/individualHonors">
                                <img className="iconImage" src={icon} alt="Individual Honors" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/seniorPhotos">
                                <img className="iconImage" src={icon} alt="Senior Photos" />
                            </Link>
                        </div>
                        <div className="control">
                            <Link to="/teams">
                                <img className="iconImage" src={icon} alt="Teams" />
                            </Link>
                        </div>
                    </div>
                
            </div>
        );
    }
}
