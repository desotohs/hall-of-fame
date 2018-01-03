using System;
using System.Collections.Generic;
using System.Linq;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service {
    public interface ITeamsService {
        IEnumerable<IGrouping<int, IActivityPicture>> GetTeams(IPageInfo page);
    }
}
