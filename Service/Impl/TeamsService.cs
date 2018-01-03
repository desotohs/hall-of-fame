using System;
using System.Collections.Generic;
using System.Linq;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class TeamsService : ITeamsService {
        [LatipiumExport]
        public IEnumerable<IGrouping<int, IActivityPicture>> GetTeams(IPageInfo page) {
            throw new NotImplementedException();
        }
    }
}
