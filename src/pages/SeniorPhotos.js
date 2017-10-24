import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from 'react-router-dom'
import "./SeniorPhotos.css";

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="seniorphotos">
                <BackgroundVideo />
                <div className="container">
                    <Link to="/seniorphotos/2017">
                        <div className="control">
                            2017
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2016">
                        <div className="control">
                            2016
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2015">
                        <div className="control">
                            2015
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2014">
                        <div className="control">
                            2014
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2013">
                        <div className="control">
                            2013
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2012">
                        <div className="control">
                            2012
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2011">
                        <div className="control">
                            2011
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2010">
                        <div className="control">
                            2010
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2009">
                        <div className="control">
                            2009
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2008">
                        <div className="control">
                            2008
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2007">
                        <div className="control">
                            2007
                        </div>
                    </Link>
                    <Link to="/seniorphotos/2006">
                        <div className="control">
                            2006
                        </div>
                    </Link>
                </div>
            </div>
        );
    }
}
