using System;
using System.Collections.Generic;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SportsRecord<T> : ISportsRecord {
        public string Name {
            get;
            private set;
        }

        public IEnumerable<ISportsRecordHolder> Season {
            get;
            private set;
        }

        public IEnumerable<ISportsCareerRecordHolder> Career {
            get;
            private set;
        }

        public IEnumerable<ISportsTeamRecord> Game {
            get;
            private set;
        }

        public IEnumerable<ISportsSeasonRecord> Team {
            get;
            private set;
        }

        public T State;

        public SportsRecord(string name, IEnumerable<ISportsRecordHolder> season, IEnumerable<ISportsCareerRecordHolder> career, IEnumerable<ISportsTeamRecord> game, IEnumerable<ISportsSeasonRecord> team, T state = default(T)) {
            Name = name;
            Season = season;
            Career = career;
            Game = game;
            Team = team;
            State = state;
        }
    }
}
