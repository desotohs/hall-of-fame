using System;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class ThemeService : IThemeService {
        [LatipiumExport]
        public byte[] Font => throw new NotImplementedException();
    }
}
