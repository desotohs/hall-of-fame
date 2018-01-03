using System;
using System.IO;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class BackgroundVideoService : IBackgroundVideoService {
        [LatipiumExport]
        static readonly byte[] backgroundVideo = File.ReadAllBytes("MockResources/BackgroundVideo.mov");

        [LatipiumExport]
        public byte[] BackgroundVideo => backgroundVideo;
    }
}
