using System;
using System.Drawing;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public interface IGraphics : IDisposable {
        event Action FrameStart;

        event Action FrameEnd;

        void FillRect(Color color, RectangleF rectangle);

        IGraphics CreateGraphics(RectangleF rectangle);
    }
}
