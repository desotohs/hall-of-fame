using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class SeniorPhotosPage : Page {
        [LatipiumImport("SeniorPhotosService")]
        public ISeniorPhotosService Service;
        [LatipiumImport]
        public IFontManager FontManager;
    }
}
