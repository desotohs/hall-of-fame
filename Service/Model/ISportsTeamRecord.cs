using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface ISportsTeamRecord {
        string Opponent {
            get;
        }

        string Value {
            get;
        }

        string Season {
            get;
        }
    }
}
