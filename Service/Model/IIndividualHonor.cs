using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface IIndividualHonor {
        string Name {
            get;
        }

        string Activity {
            get;
        }

        string Accomplishment {
            get;
        }
    }
}
