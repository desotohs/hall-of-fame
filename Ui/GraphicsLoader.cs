using System;
using System.Drawing;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    [LatipiumLoader]
    public static class GraphicsLoader {
        static void CreateRect(Window window, Color color, byte alpha, float x, float y, float width, float height) {
            Component test = new Component();
            test.Background = Color.FromArgb(alpha, color);
            test.Bounds = new RectangleF(x, y, width, height);
            window.Add(test);
        }

        [LatipiumLoadMethod]
        public static void Start() {
            Window win = new Window();
            CreateRect(win, Color.Red, 255, 0, 0, 0.5f, 0.5f);
            CreateRect(win, Color.Green, 255, 0, 0.6f, 0.8f, 0.3f);
            CreateRect(win, Color.Blue, 127, 0.2f, 0.1f, 0.5f, 0.7f);
        }
    }
}
