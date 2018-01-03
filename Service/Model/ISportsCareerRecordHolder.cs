using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface ISportsCareerRecordHolder {
        string Name {
            get;
        }

        string Value {
            get;
        }

        int StartYear {
            get;
        }

        int EndYear {
            get;
        }
    }
}
