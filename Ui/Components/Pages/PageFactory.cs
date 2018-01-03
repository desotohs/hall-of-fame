using System;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    [LatipiumExportClass(0)]
    public class PageFactory : IPageFactory {
        [LatipiumExport]
        public Page CreatePage(IPageInfo info) {
            Page page;
            switch (info.Type) {
                case PageType.AllTimeRecords:
                    page = new AllTimeRecordsPage();
                    break;
                case PageType.HallOfFame:
                    page = new HallOfFamePage();
                    break;
                case PageType.IndividualHonors:
                    page = new IndividualHonorsPage();
                    break;
                case PageType.SeniorPhotos:
                    page = new SeniorPhotosPage();
                    break;
                case PageType.Teams:
                    page = new TeamsPage();
                    break;
                default:
                    throw new ArgumentException("Invalid page type");
            }
            page.PageInfo = info;
            return page;
        }
    }
}
