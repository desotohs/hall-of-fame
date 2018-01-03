using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Com.GitHub.ZachDeibert.GraphicsCore;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Window : Container {
        const float MaxClickMovement = 0.01f;
        static readonly TimeSpan MaxClickTime = TimeSpan.FromSeconds(0.5);
        [LatipiumImport("Graphics")]
        public IGraphics Gfx;
        bool IsMouseDown;
        bool IsClick;
        PointF Mouse;
        PointF ClickStart;
        CancellationTokenSource ClickCTS;
        int ClickNonce;

        void OnMouseClick(MouseButton button, KeyModifiers modifiers) {
            int nonce = ++ClickNonce;
            if (ClickCTS != null) {
                ClickCTS.Cancel();
            }
            IsMouseDown = true;
            DispatchMouseDown(Mouse);
            IsClick = true;
            ClickStart = Mouse;
            ClickCTS = new CancellationTokenSource();
            Task.Delay(MaxClickTime, ClickCTS.Token).ContinueWith(t => {
                if (IsClick && ClickNonce == nonce && t.IsCanceled) {
                    DispatchMouseClick(ClickStart);
                }
            });
        }

        void OnMouseMove(double x, double y) {
            PointF old = Mouse;
            Mouse = Graphics.ConvertPoint(new Point((int) x, (int) y), Gfx);
            Mouse = new PointF(Mouse.X, 1 - Mouse.Y);
            if (IsMouseDown) {
                DispatchMouseDrag(new PointF(Mouse.X - old.X, Mouse.Y - old.Y));
                float dx = ClickStart.X - Mouse.X;
                float dy = ClickStart.Y - Mouse.Y;
                if (Math.Sqrt(dx * dx + dy * dy) > MaxClickMovement) {
                    IsClick = false;
                    ClickCTS.Cancel();
                }
            }
        }

        void OnMouseRelease(MouseButton button, KeyModifiers modifiers) {
            IsMouseDown = false;
            DispatchMouseUp(Mouse);
            ClickCTS.Cancel();
        }

        public Window() {
            Gfx.FrameStart += () => DrawAll(Gfx);
            Gfx.RawContext.Input.Window.Resize += (w, h) => Invalidate();
            Gfx.RawContext.Input.Window.ViewportResize += (w, h) => Invalidate();
            Gfx.RawContext.Input.Mouse.Click += OnMouseClick;
            Gfx.RawContext.Input.Mouse.Move += OnMouseMove;
            Gfx.RawContext.Input.Mouse.Release += OnMouseRelease;
        }
    }
}
