import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
import { Link } from "react-router-dom";
import IconManager from "../database/IconManager";
import "./StateChampions.css";

export default class StateChampions extends React.Component {
    constructor(props) {
        super(props);
        const icons = new IconManager(this);
        icons.get("Band", "bandIcon");
        icons.get("Basketball.Boys", "boysBasketballIcon");
        icons.get("Basketball.Girls", "girlsBasketballIcon");
        icons.get("Bowling", "bowlingIcon");
        icons.get("Boys.Golf", "boysGolfIcon");
        icons.get("Cheer", "cheerIcon");
        icons.get("Debate", "debateIcon");
        icons.get("Girls Swim", "girlsSwimIcon");
        icons.get("Scholars Bowl", "scholarsBowlIcon");
        icons.get("Soccer", "soccerIcon");
        icons.get("Tennis", "tennisIcon");
        icons.get("Theatre", "theatreIcon");
        icons.get("Volleyball", "volleyballIcon");
    }

    render() {
        return (
            <div className="statechampions">
                <BackgroundVideo />
                <h2 className="foregreen header">State Champs</h2>
                <div className="container">
                <div className="control">
                    <Link to="/statechampions/band">
                        <img className="iconImage" src={this.icons.bandIcon} alt="Band" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/boys-basketball">
                        <img className="iconImage" src={this.icons.boysBasketballIcon} alt="Boys Basketball" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/girls-basketball">
                        <img className="iconImage" src={this.icons.girlsBasketballIcon} alt="Girls Basketball" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/bowling">
                        <img className="iconImage" src={this.icons.bowlingIcon} alt="Bowling" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/debate">
                        <img className="iconImage" src={this.icons.debateIcon} alt="Debate" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/boys-golf">
                        <img className="iconImage" src={this.icons.boysGolfIcon} alt="Boys Golf" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/scholars-bowl">
                        <img className="iconImage" src={this.icons.scholarsBowlIcon} alt="Scholars Bowl" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/soccer">
                        <img className="iconImage" src={this.icons.soccerIcon} alt="Soccer" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/girls-swim">
                        <img className="iconImage" src={this.icons.girlsSwimIcon} alt="Girls Swim" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/tennis">
                        <img className="iconImage" src={this.icons.tennisIcon} alt="Tennis" />
                    </Link>
                </div>
                <div className="control">
                    <Link to="/statechampions/volleyball">
                        <img className="iconImage" src={this.icons.volleyballIcon} alt="Volleyball" />
                    </Link>
                </div>
                </div>
            </div>
        );
    }
}
