using System;
using System.Collections.Generic;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface ISportRecords {
        string Name {
            get;
        }

        IEnumerable<ISportsRecord> Records {
            get;
        }
    }
}
