using System;
using System.Drawing;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Component : LatipiumObject {
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
        public event Action BoundsChanged;

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

        public Component() {
            Bounds = new RectangleF(0, 0, 1, 1);
        }
    }
}
