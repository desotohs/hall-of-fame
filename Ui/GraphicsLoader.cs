using System;
using System.Drawing;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    [LatipiumLoader]
    public static class GraphicsLoader {
        [LatipiumLoadMethod]
        public static void Start() {
            Window win = new Window();
            MainMenu menu = new MainMenu();
            menu.Bounds = new RectangleF(0, 0, 1, 1);
            win.Add(menu);
        }
    }
}
