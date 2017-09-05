import React from "react";
import logo from "./logo.svg";
import HomeScreen from "./pages/HomeScreen.js"
import "./App.css";
import CDNotification from "./CDNotification";
import "materialize-css/dist/css/materialize.css";

export default class App extends React.Component {
    render() {
        return (
            <div>
                <HomeScreen />
                <CDNotification />
            </div>
        );
    }
}
