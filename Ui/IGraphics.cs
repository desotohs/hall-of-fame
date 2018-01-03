using System;
using System.Drawing;
using Com.GitHub.ZachDeibert.GraphicsCore;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public interface IGraphics : IDisposable {
        IOpenGLContext RawContext {
            get;
        }

        RectangleF GlobalPosition {
            get;
        }

        IDisposable TextureLock {
            get;
        }

        bool TextureLocked {
            get;
        }

        IDisposable ShaderLock {
            get;
        }

        bool ShaderLocked {
            get;
        }

        event Action FrameStart;

        event Action FrameEnd;

        void FillRect(Color color, RectangleF rectangle);

        void DrawImage(Image image, RectangleF rectangle);

        RectangleF MeasureString(Font font, string str, float size = 1);

        void DrawString(Font font, string str, Color color, PointF origin, float size = 1);

        IGraphics CreateGraphics(RectangleF rectangle);

        void SynchronizedTask(Action action);
    }
}
