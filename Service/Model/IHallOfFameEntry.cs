using System;
using System.Collections.Generic;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface IHallOfFameEntry {
        string Name {
            get;
        }

        int Year {
            get;
        }

        byte[] Picture {
            get;
        }

        string Essay {
            get;
        }

        IEnumerable<IMedia> Media {
            get;
        }
    }
}
