import React from "react";
import {BrowserRouter, Switch, Route} from "react-router-dom";
import AppContainer from "./AppContainer";
import HomeScreen from "./pages/HomeScreen";
import StateChampions from "./pages/StateChampions";
import StateChampionClubs from "./pages/StateChampionClub";
import SeniorPhotos from "./pages/SeniorPhotos";
import SeniorPhotosYear from "./pages/SeniorPhotosYear";
import "./App.css";
import CDNotification from "./CDNotification";
import "materialize-css/dist/css/materialize.css";
import "./database/GDrive";
import NavBar from "./NavBar";

export default class App extends React.Component {
    render() {
        return (
            <AppContainer>
                <BrowserRouter>
                    <Switch>
                        <Route path="/seniorphotos/:year" component={SeniorPhotosYear} />
                        <Route path="/seniorphotos" component={SeniorPhotos} />
                        <Route path="/statechampions/:club" component={StateChampionClubs} />
                        <Route path="/statechampions" component={StateChampions} />
                        <Route component={HomeScreen} />
                    </Switch>
                </BrowserRouter>
                <CDNotification />
                <NavBar/>
            </AppContainer>
        );
    }
}
