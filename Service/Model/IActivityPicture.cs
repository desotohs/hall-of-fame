using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface IActivityPicture {
        string Name {
            get;
        }

        byte[] Picture {
            get;
        }

        string Description {
            get;
        }
    }
}
