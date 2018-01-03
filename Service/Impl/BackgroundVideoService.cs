using System;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class BackgroundVideoService : IBackgroundVideoService {
        [LatipiumExport]
        public byte[] BackgroundVideo => throw new NotImplementedException();
    }
}
