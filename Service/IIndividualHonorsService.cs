using System;
using System.Collections.Generic;
using System.Linq;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service {
    public interface IIndividualHonorsService {
        IEnumerable<IGrouping<int, IIndividualHonor>> GetHonors(IPageInfo page);
    }
}
