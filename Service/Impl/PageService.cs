using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Impl {
    [LatipiumExportClass(ServicePriorities.Impl)]
    public class PageService : IPageService {
        public IEnumerable<IPageInfo> Pages => throw new NotImplementedException();

        public string AppTitle => throw new NotImplementedException();

        public byte[] HeaderImage => throw new NotImplementedException();
    }
}
