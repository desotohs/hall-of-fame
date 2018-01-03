using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SportsRecordHolder<T> : ISportsRecordHolder {
        public string Name {
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

        public int Grade {
            get;
            private set;
        }

        public T State;

        public SportsRecordHolder(string name, string value, string season, int grade, T state = default(T)) {
            Name = name;
            Value = value;
            Season = season;
            Grade = grade;
            State = state;
        }
    }
}
