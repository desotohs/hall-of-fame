using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service {
    public interface IAllTimeRecordsService {
        IEnumerable<ISportRecords> GetRecords(IPageInfo page);
    }
}
