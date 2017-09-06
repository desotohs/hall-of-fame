import React from "react";
import {BrowserRouter, Switch, Route} from "react-router-dom";
import HomeScreen from "./pages/HomeScreen.js"
import "./App.css";
import CDNotification from "./CDNotification";
import "materialize-css/dist/css/materialize.css";

export default class App extends React.Component {
    render() {
        return (
            <div>
                <BrowserRouter>
                    <Switch>
                        <Route component={HomeScreen} />
                    </Switch>
                </BrowserRouter>
                <CDNotification />
            </div>
        );
    }
}
