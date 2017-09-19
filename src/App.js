import React from "react";
import {BrowserRouter, Switch, Route} from "react-router-dom";
import HomeScreen from "./pages/HomeScreen";
import StateChampions from "./pages/StateChampions";
import "./App.css";
import CDNotification from "./CDNotification";
import "materialize-css/dist/css/materialize.css";
import "./database/GDrive";

export default class App extends React.Component {
    render() {
        return (
            <div>
                <BrowserRouter>
                    <Switch>
                        <Route path="/statechamps" component={StateChampions} />
                        <Route path="/statechampions" component={StateChampions} />
                        <Route component={HomeScreen} />
                    </Switch>
                </BrowserRouter>
                <CDNotification />
            </div>
        );
    }
}
