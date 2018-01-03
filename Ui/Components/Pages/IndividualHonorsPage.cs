using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class IndividualHonorsPage : Page {
        [LatipiumImport("IndividualHonorsService")]
        public IIndividualHonorsService Service;
        [LatipiumImport]
        public IFontManager FontManager;
    }
}
