using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service {
    public interface IHallOfFameService {
        IEnumerable<IHallOfFameEntry> GetEntries(IPageInfo page);
    }
}
