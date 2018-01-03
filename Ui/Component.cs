using System;
using System.Drawing;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Component : LatipiumObject, IDisposable {
        public Color Background = Color.WhiteSmoke;
        Container parent;
        public virtual Container Parent {
            get => parent;
            set {
                parent = value;
                if (!Parent.Contains(this)) {
                    Parent.Add(this);
                }
                Invalidate();
            }
        }
        RectangleF bounds;
        public RectangleF Bounds {
            get => bounds;
            set {
                bounds = value;
                BoundsChanged?.Invoke();
                Invalidate();
            }
        }
        public bool Disposed {
            get;
            protected set;
        }
        public event Action BoundsChanged;
        public event Action<PointF> MouseClick;
        public event Action<PointF> MouseDown;
        public event Action<PointF> MouseUp;
        public event Action<PointF> MouseDrag;

        public void DispatchMouseClick(PointF point) {
            MouseClick?.Invoke(point);
        }

        public void DispatchMouseDown(PointF point) {
            MouseDown?.Invoke(point);
        }

        public void DispatchMouseUp(PointF point) {
            MouseUp?.Invoke(point);
        }

        public void DispatchMouseDrag(PointF point) {
            MouseDrag?.Invoke(point);
        }

        public virtual void Draw(IGraphics g) {
        }

        public virtual void DrawBackground(IGraphics g) {
            g.FillRect(Background, new RectangleF(0, 0, 1, 1));
        }

        public virtual void DrawAll(IGraphics g) {
            DrawBackground(g);
            Draw(g);
        }

        public virtual void Invalidate() {
            Parent?.InvalidateComponent(this);
        }

        protected virtual void Dispose(bool disposing) {
        }

        public void Dispose() {
            Dispose(true);
        }

        public Component() {
            Bounds = new RectangleF(0, 0, 1, 1);
        }
    }
}
