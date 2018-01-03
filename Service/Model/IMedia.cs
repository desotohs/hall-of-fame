using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface IMedia {
        string Name {
            get;
        }

        byte[] Content {
            get;
        }
    }
}
