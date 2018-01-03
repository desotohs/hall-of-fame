using System;
using System.Drawing;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class MainMenu : Container {
        [LatipiumImport]
        public IFontManager FontManager;
        [LatipiumImport]
        public IPageFactory PageFactory;

        public override void Draw(IGraphics g) {
            g.DrawString(FontManager.GetFont(300), "Hello, world!", Color.Black, PointF.Empty);
        }

        public MainMenu() {
            FontManager.GetFont(300);
        }
    }
}
