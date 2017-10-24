// TODO a bunch of this file needs to be changed to use the new `IconManager`

import React from "react";
import BackgroundVideo from "../components/BackgroundVideo";
/*
import band from "../media/images/Band.png";
import boysbasketball from "../media/images/Basketball.Boys.png";
import girlsbasketball from "../media/images/Basketball.Girls.png";
import bowling from "../media/images/Bowling.png";
import boysgolf from "../media/images/Boys.Golf.png";
import cheer from "../media/images/Cheer.png";
import debate from "../media/images/Debate.png";
import girlsswim from "../media/images/Girls Swim.png";
import scholarsbowl from "../media/images/Scholars Bowl.png";
import soccer from "../media/images/Soccer.png";
import tennis from "../media/images/Tennis.png";
import theatre from "../media/images/Theatre.png";
import volleyball from "../media/images/Volleyball.png";
*/
import image from "../database/failover/image-error.png";
import "./StateChampionClub.css";

export default class StateChampions extends React.Component {
    render() {
        return (
            <div className="statechampionclub">
                {/* <h2 className="clubtitle"> {
                    doTitle(this.props.match.params.club)
                } </h2> */}
                <BackgroundVideo />
                <img className="iconImage" src={/*images[doImageName(this.props.match.params.club)]*/ image} alt={doImageName(this.props.match.params.club)} />
            </div>
        );
    }
     
}
/*
var images = {"band": band, "boysbasketball": boysbasketball, "girlsbasketball": girlsbasketball,
    "bowling": bowling, "boysgolf": boysgolf, "cheer": cheer, "debate": debate,"girlsswim": girlsswim,
    "scholarsbowl": scholarsbowl, "soccer": soccer, "tennis": tennis, "theatre": theatre, "volleyball": volleyball};
*/

function doTitle(club){
    var words = club.split("-")
    var result = "";
    for(var i = 0; i < words.length; i++){
        result = result + words[i].charAt(0).toUpperCase() + words[i].slice(1) + " ";
    }
    return result
}

function doImageName(club){
    var words = club.split("-")
    var result = "";
    for(var i = 0; i < words.length; i++){
        result = result + words[i];
    }
    return result
}
