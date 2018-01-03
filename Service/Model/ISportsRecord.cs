using System;
using System.Collections.Generic;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface ISportsRecord {
        string Name {
            get;
        }

        IEnumerable<ISportsRecordHolder> Season {
            get;
        }

        IEnumerable<ISportsCareerRecordHolder> Career {
            get;
        }

        IEnumerable<ISportsTeamRecord> Game {
            get;
        }

        IEnumerable<ISportsSeasonRecord> Team {
            get;
        }
    }
}
