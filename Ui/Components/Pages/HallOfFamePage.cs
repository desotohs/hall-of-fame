using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class HallOfFamePage : Page {
        [LatipiumImport("HallOfFameService")]
        public IHallOfFameService Service;
        [LatipiumImport]
        public IFontManager FontManager;
    }
}
