using System;
using System.Collections.Generic;
using System.Linq;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service {
    public interface ISeniorPhotosService {
        IEnumerable<IGrouping<int, ISeniorPhoto>> GetPhotos(IPageInfo page);
    }
}
