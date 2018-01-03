using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SportsCareerRecordHolder<T> : ISportsCareerRecordHolder {
        public string Name {
            get;
            private set;
        }

        public string Value {
            get;
            private set;
        }

        public int StartYear {
            get;
            private set;
        }

        public int EndYear {
            get;
            private set;
        }

        public T State;

        public SportsCareerRecordHolder(string name, string value, int startYear, int endYear, T state = default(T)) {
            Name = name;
            Value = value;
            StartYear = startYear;
            EndYear = endYear;
            State = state;
        }
    }
}
