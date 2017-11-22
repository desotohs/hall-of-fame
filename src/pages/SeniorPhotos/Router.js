import React from "react";
import { Route } from "react-router-dom";
import MainPage from "./MainPage";
import Year from "./Year";

export default function getRoutes(url) {
    return [
        <Route path={`${url}/:year`} component={Year} />,
        <Route path={url} component={MainPage} />
    ];
}
