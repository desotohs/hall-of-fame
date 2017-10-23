import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from 'react-router-dom'
import icon from "../media/images/logo.png";
import bandIcon from "../media/images/Band.png";
import boysBasketballIcon from "../media/images/Basketball.Boys.png";
import girlsBasketballIcon from "../media/images/Basketball.Girls.png";
import bowlingIcon from "../media/images/Bowling.png";
import boysGolfIcon from "../media/images/Boys.Golf.png";
import cheerIcon from "../media/images/Cheer.png";
import debateIcon from "../media/images/Debate.png";
import girlsSwimIcon from "../media/images/Girls Swim.png";
import scholarsBowlIcon from "../media/images/Scholars Bowl.png";
import soccerIcon from "../media/images/Soccer.png";
import tennisIcon from "../media/images/Tennis.png";
import theatreIcon from "../media/images/Theatre.png";
import volleyballIcon from "../media/images/Volleyball.png";
import "./StateChampions.css";

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="statechampions">
            <h2>{this.props.match.params.club.charAt(0).toUpperCase() + this.props.match.params.club.slice(1)}</h2>
            <BackgroundVideo />
            </div>
        );
    }
}
