import React from "react";
import {BrowserRouter, Switch, Route} from "react-router-dom";
import loadCSV from "./database/CSVFile";
import AppContainer from "./AppContainer";
import ContinuousDelivery from "./ContinuousDelivery";
import NavBar from "./NavBar";
import HomeScreen from "./pages/HomeScreen";
import LoadingPage from "./pages/LoadingPage";
import "materialize-css/dist/css/materialize.css";
import "./App.css";

import HallOfFame from "./pages/HallOfFame/Router";
import SeniorPhotos from "./pages/SeniorPhotos/Router";
const pageClasses = {
    "HallOfFame": HallOfFame,
    "SeniorPhotos": SeniorPhotos
};

export default class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            "routes": []
        };
        loadCSV("/Table of Contents", csv => {
            this.setState({
                "routes": csv.toArray().map(row => {
                    let cls = pageClasses[row.get("Page Class")];
                    if (cls) {
                        return cls(row.get("Page URL"));
                    } else {
                        console.error(`Unknown page class '${row.get("Page Class")}'`);
                        return null;
                    }
                })
            });
        });
    }

    render() {
        return (
            <AppContainer>
                <LoadingPage />
                <BrowserRouter>
                    <div className="fullscreen">
                        <Switch>
                            {this.state.routes}
                            <Route component={HomeScreen} />
                        </Switch>
                        <NavBar />
                    </div>
                </BrowserRouter>
                <ContinuousDelivery />
            </AppContainer>
        );
    }
}
