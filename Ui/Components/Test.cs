using System;
using System.Drawing;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components {
    public class Test : Component {
        Image image = new Image("boot.png");

        public override void Draw(IGraphics g) {
            g.DrawImage(image, new RectangleF(0, 0, 1, 1));
        }
    }
}
