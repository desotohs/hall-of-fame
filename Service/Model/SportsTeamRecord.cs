using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SportsTeamRecord<T> : ISportsTeamRecord {
        public string Opponent {
            get;
            private set;
        }

        public string Value {
            get;
            private set;
        }

        public string Season {
            get;
            private set;
        }

        public T State;

        public SportsTeamRecord(string opponent, string value, string season, T state = default(T)) {
            Opponent = opponent;
            Value = value;
            Season = season;
            State = state;
        }
    }
}
