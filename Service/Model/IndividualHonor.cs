using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class IndividualHonor<T> : IIndividualHonor {
        public string Name {
            get;
            private set;
        }

        public string Activity {
            get;
            private set;
        }

        public string Accomplishment {
            get;
            private set;
        }

        public T State;

        public IndividualHonor(string name, string activity, string accomplishment, T state = default(T)) {
            Name = name;
            Activity = activity;
            Accomplishment = accomplishment;
            State = state;
        }
    }
}
