using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface ISeniorPhoto {
        string Name {
            get;
        }

        byte[] Picture {
            get;
        }
    }
}
