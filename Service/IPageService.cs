using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service {
    public interface IPageService {
        IEnumerable<IPageInfo> Pages {
            get;
        }

        string AppTitle {
            get;
        }

        byte[] HeaderImage {
            get;
        }
    }
}
