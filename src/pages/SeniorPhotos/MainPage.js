import React from "react";
import BackgroundVideo from "../../components/BackgroundVideo";
import { Link } from "react-router-dom";
import "./MainPage.css";

export default class MainPage extends React.Component {
    render() {
        return (
            <div className="seniorphotos">
                <BackgroundVideo />
                <h2 className="header foregreen"> Senior Photos </h2>
                <div className="container">
                    <Link to="/seniorphotos/2017">
                        <div className="control foregreen">
                            2017
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2016">
                        <div className="control foregreen">
                            2016
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2015">
                        <div className="control foregreen">
                            2015
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2014">
                        <div className="control foregreen">
                            2014
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2013">
                        <div className="control foregreen">
                            2013
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2012">
                        <div className="control foregreen">
                            2012
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2011">
                        <div className="control foregreen">
                            2011
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2010">
                        <div className="control foregreen">
                            2010
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2009">
                        <div className="control foregreen">
                            2009
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2008">
                        <div className="control foregreen">
                            2008
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2007">
                        <div className="control foregreen">
                            2007
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2006">
                        <div className="control foregreen">
                            2006
                        </div>
                    </Link>
                </div>
            </div>
        );
    }
}
