using System;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Window : Container {
        [LatipiumImport]
        public IGraphics Graphics;

        public Window() {
            Graphics.FrameStart += () => DrawAll(Graphics);
        }
    }
}
