using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class AllTimeRecordsService : IAllTimeRecordsService {
        public IEnumerable<ISportRecords> GetRecords(IPageInfo page) {
            throw new NotImplementedException();
        }
    }
}
