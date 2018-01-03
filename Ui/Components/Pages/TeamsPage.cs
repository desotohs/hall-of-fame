using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class TeamsPage : Page {
        [LatipiumImport("TeamsService")]
        public ITeamsService Service;
        [LatipiumImport]
        public IFontManager FontManager;
    }
}
