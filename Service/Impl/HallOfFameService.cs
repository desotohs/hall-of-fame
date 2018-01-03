using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class HallOfFameService : IHallOfFameService {
        public IEnumerable<IHallOfFameEntry> GetEntries(IPageInfo page) {
            throw new NotImplementedException();
        }
    }
}
