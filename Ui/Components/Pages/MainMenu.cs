using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class MainMenu : Container {
        [LatipiumImport]
        public IFontManager FontManager;
        [LatipiumImport]
        public IPageFactory PageFactory;
    }
}
