using System;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Window : Container {
        [LatipiumImport]
        public IGraphics Graphics;

        public Window() {
            Graphics.FrameStart += () => DrawAll(Graphics);
            Graphics.RawContext.Input.Window.Resize += (w, h) => Invalidate();
            Graphics.RawContext.Input.Window.ViewportResize += (w, h) => Invalidate();
        }
    }
}
