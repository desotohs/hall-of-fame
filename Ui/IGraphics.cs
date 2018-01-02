using System;
using System.Drawing;
using Com.GitHub.ZachDeibert.GraphicsCore;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public interface IGraphics : IDisposable {
        IOpenGLContext RawContext {
            get;
        }

        event Action FrameStart;

        event Action FrameEnd;

        void FillRect(Color color, RectangleF rectangle);

        void DrawImage(Image image, RectangleF rectangle);

        IGraphics CreateGraphics(RectangleF rectangle);
    }
}
