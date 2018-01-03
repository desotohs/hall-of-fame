using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class AllTimeRecordsPage : Page {
        [LatipiumImport("AllTimeRecordsService")]
        public IAllTimeRecordsService Service;
        [LatipiumImport]
        public IFontManager FontManager;
    }
}
