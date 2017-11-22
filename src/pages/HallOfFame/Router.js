import React from "react";
import { Route } from "react-router-dom";
import MainPage from "./MainPage";
import Club from "./Club";

export default function getRoutes(url) {
    return [
        <Route path={`${url}/:club`} component={Club} />,
        <Route path={url} component={MainPage} />
    ];
}
