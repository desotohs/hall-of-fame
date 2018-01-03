using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Container : Component, IList<Component> {
        List<Component> Components;
        List<Component> InvalidComponents;
        bool ActuallyDirty;
        Component DragComponent;

        void OnMouseClick(PointF point) {
            Component c = ComponentAt(point);
            if (c != null) {
                c.DispatchMouseClick(new PointF(c.Bounds.Width * (point.X - c.Bounds.X), c.Bounds.Height * (point.Y - c.Bounds.Y)));
            }
        }

        void OnMouseDown(PointF point) {
            DragComponent = ComponentAt(point);
            if (DragComponent != null) {
                DragComponent.DispatchMouseDown(new PointF(DragComponent.Bounds.Width * (point.X - DragComponent.Bounds.X), DragComponent.Bounds.Height * (point.Y - DragComponent.Bounds.Y)));
            }
        }

        void OnMouseDrag(PointF delta) {
            Component c = ComponentAt(delta);
            if (c != null) {
                c.DispatchMouseDrag(new PointF(c.Bounds.Width * delta.X, c.Bounds.Height * delta.Y));
            }
        }

        void OnMouseUp(PointF point) {
            Component c = ComponentAt(point);
            if (c != null) {
                c.DispatchMouseUp(new PointF(c.Bounds.Width * (point.X - c.Bounds.X), c.Bounds.Height * (point.Y - c.Bounds.Y)));
            }
        }

        public Component ComponentAt(PointF point) {
            return Components.FirstOrDefault(c => c.Bounds.Contains(point));
        }

        public override void Draw(IGraphics g) {
            foreach (Component c in (ActuallyDirty ? Components : InvalidComponents)) {
                using (IGraphics g2 = g.CreateGraphics(c.Bounds)) {
                    c.DrawAll(g2);
                }
            }
            InvalidComponents.Clear();
            ActuallyDirty = false;
        }

        public override void DrawBackground(IGraphics g) {
            if (ActuallyDirty) {
                base.DrawBackground(g);
            } else {
                foreach (Component component in InvalidComponents) {
                    g.FillRect(Background, component.Bounds);
                }
            }
        }

        public override void Invalidate() {
            ActuallyDirty = true;
            base.Invalidate();
            if (Components != null) {
                // The Component constructor invalidates itself (before we can initialize the lists)
                foreach (Container c in this.OfType<Container>()) {
                    c.Invalidate();
                }
            }
        }

        public void InvalidateComponent(Component component) {
            if (Components.Contains(component) && !InvalidComponents.Contains(component)) {
                InvalidComponents.Add(component);
                base.Invalidate();
            }
        }

        Component Register(Component c) {
            c.BoundsChanged += Invalidate;
            return c;
        }

        void Deregister(Component c) {
            c.BoundsChanged -= Invalidate;
        }

        public Container() {
            Components = new List<Component>();
            InvalidComponents = new List<Component>();
            ActuallyDirty = true;
            MouseClick += OnMouseClick;
            MouseDown += OnMouseDown;
            MouseDrag += OnMouseDrag;
            MouseUp += OnMouseUp;
        }

#region List Implementation
        public Component this[int index] {
            get => ((IList<Component>)Components)[index];
            set {
                ((IList<Component>)Components)[index] = Register(value);
                Invalidate();
            }
        }

        public int Count => ((IList<Component>)Components).Count;

        public bool IsReadOnly => ((IList<Component>)Components).IsReadOnly;

        public void Add(Component item) {
            ((IList<Component>)Components).Add(Register(item));
            Invalidate();
        }

        public void Clear() {
            foreach (Component c in this) {
                Deregister(c);
            }
            ((IList<Component>)Components).Clear();
            Invalidate();
        }

        public bool Contains(Component item) {
            return ((IList<Component>)Components).Contains(item);
        }

        public void CopyTo(Component[] array, int arrayIndex) {
            ((IList<Component>)Components).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Component> GetEnumerator() {
            return ((IList<Component>)Components).GetEnumerator();
        }

        public int IndexOf(Component item) {
            return ((IList<Component>)Components).IndexOf(item);
        }

        public void Insert(int index, Component item) {
            ((IList<Component>)Components).Insert(index, Register(item));
            Invalidate();
        }

        public bool Remove(Component item) {
            bool res = ((IList<Component>)Components).Remove(item);
            if (res) {
                Deregister(item);
            }
            Invalidate();
            return res;
        }

        public void RemoveAt(int index) {
            Deregister(this[index]);
            ((IList<Component>)Components).RemoveAt(index);
            Invalidate();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IList<Component>)Components).GetEnumerator();
        }
#endregion
    }
}
