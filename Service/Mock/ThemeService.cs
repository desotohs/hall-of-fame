using System;
using System.IO;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class ThemeService : IThemeService {
        static readonly byte[] font = File.ReadAllBytes("MockResources/Ubuntu-R.ttf");

        [LatipiumExport]
        public byte[] Font => font;
    }
}
