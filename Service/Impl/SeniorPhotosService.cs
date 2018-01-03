using System;
using System.Collections.Generic;
using System.Linq;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class SeniorPhotosService : ISeniorPhotosService {
        [LatipiumExport]
        public IEnumerable<IGrouping<int, ISeniorPhoto>> GetPhotos(IPageInfo page) {
            throw new NotImplementedException();
        }
    }
}
