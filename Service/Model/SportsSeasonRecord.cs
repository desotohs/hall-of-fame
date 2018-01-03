using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SportsSeasonRecord<T> : ISportsSeasonRecord {
        public string Season {
            get;
            private set;
        }

        public string Value {
            get;
            private set;
        }

        public T State;

        public SportsSeasonRecord(string season, string value, T state = default(T)) {
            Season = season;
            Value = value;
            State = state;
        }
    }
}
