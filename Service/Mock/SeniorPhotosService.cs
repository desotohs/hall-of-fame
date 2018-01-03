using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class SeniorPhotosService : ISeniorPhotosService {
        static readonly IEnumerable<IGrouping<int, ISeniorPhoto>> SeniorPhotos = new [] {
            new Tuple<int, ISeniorPhoto>(2017, new SeniorPhoto<object>("John Doe", File.ReadAllBytes("MockResources/Photo0.png"))),
            new Tuple<int, ISeniorPhoto>(2017, new SeniorPhoto<object>("Jane Doe", File.ReadAllBytes("MockResources/Photo1.png"))),
            new Tuple<int, ISeniorPhoto>(2016, new SeniorPhoto<object>("Power Outlet", File.ReadAllBytes("MockResources/Photo2.png")))
        }.GroupBy(t => t.Item1, t => t.Item2);

        [LatipiumExport]
        public IEnumerable<IGrouping<int, ISeniorPhoto>> GetPhotos(IPageInfo page) {
            switch (((PageInfo<int>) page).State) {
                case 4:
                    return SeniorPhotos;
                default:
                    throw new ArgumentException("Invalid page");
            }
        }
    }
}
