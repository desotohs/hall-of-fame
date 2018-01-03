using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface ISportsRecordHolder {
        string Name {
            get;
        }

        string Value {
            get;
        }

        string Season {
            get;
        }

        int Grade {
            get;
        }
    }
}
