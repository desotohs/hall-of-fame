using System;
using System.Drawing;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components {
    public class Test : Component {
        Image image = new Image("boot.png");
        Font font = new Font("Ubuntu-R.ttf");

        public override void Draw(IGraphics g) {
            g.DrawImage(image, new RectangleF(0, 0, 1, 1));
            g.DrawString(font, "Hello, world!", Color.Yellow, new PointF(0, 0.2f));
        }
    }
}
