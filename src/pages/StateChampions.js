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
                <BackgroundVideo />
                <div className="container">
                <div className="control">
                    <Link to="/band">
                        <img className="iconImage" src={bandIcon} alt="Band" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/boys-basketball">
                        <img className="iconImage" src={boysBasketballIcon} alt="Boys Basketball" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/girls-basketball">
                        <img className="iconImage" src={girlsBasketballIcon} alt="Girls Basketball" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/bowling">
                        <img className="iconImage" src={bowlingIcon} alt="Bowling" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/cheer">
                        <img className="iconImage" src={cheerIcon} alt="Cheer" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/debate">
                        <img className="iconImage" src={debateIcon} alt="Debate" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/boys-golf">
                        <img className="iconImage" src={boysGolfIcon} alt="Boys Golf" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/scholars-bowl">
                        <img className="iconImage" src={scholarsBowlIcon} alt="Scholars Bowl" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/soccer">
                        <img className="iconImage" src={soccerIcon} alt="Soccer" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/girls-swim">
                        <img className="iconImage" src={girlsSwimIcon} alt="Girls Swim" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/tennis">
                        <img className="iconImage" src={tennisIcon} alt="Tennis" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/theatre">
                        <img className="iconImage" src={theatreIcon} alt="Theatre" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/volleyball">
                        <img className="iconImage" src={volleyballIcon} alt="Volleyball" />
                    </Link>
                </div>
                </div>
            </div>
        );
    }
}
