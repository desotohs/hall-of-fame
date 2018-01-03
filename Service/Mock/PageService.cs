using System;
using System.Collections.Generic;
using System.IO;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class PageService : IPageService {
        readonly static byte[] headerImage = File.ReadAllBytes("MockResources/HeaderImage.jpg");
        readonly static IPageInfo[] pages = new IPageInfo[] {
            new PageInfo<int>("Hall of Fame", PageType.HallOfFame, File.ReadAllBytes("MockResources/Hall of Fame.png"), 0),
            new PageInfo<int>("State Champions", PageType.HallOfFame, File.ReadAllBytes("MockResources/State Champs.png"), 1),
            new PageInfo<int>("All-Time Records", PageType.AllTimeRecords, File.ReadAllBytes("MockResources/All Time Records.png"), 2),
            new PageInfo<int>("Individual Honors", PageType.IndividualHonors, File.ReadAllBytes("MockResources/Individual Honors.png"), 3),
            new PageInfo<int>("Senior Photos", PageType.SeniorPhotos, File.ReadAllBytes("MockResources/Senior Photos.png"), 4),
            new PageInfo<int>("Team Photos", PageType.Teams, File.ReadAllBytes("MockResources/Team Photos.png"), 5)
        };

        [LatipiumExport]
        public IEnumerable<IPageInfo> Pages => pages;

        [LatipiumExport]
        public string AppTitle => "DHS Hall of Fame";

        [LatipiumExport]
        public byte[] HeaderImage => headerImage;
    }
}
