using System;
using System.Collections.Generic;
using System.Drawing;
using Com.GitHub.ZachDeibert.GraphicsCore;
using Com.Latipium.Core;
using Com.Latipium.Core.Discovery;
using Com.GitHub.DesotoHS.HallOfFame.Util;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    [Application, LatipiumExportClass("Graphics")]
    public class Graphics : IApplication, IGraphics {
        static IOpenGLContext Gl;
        static Size ViewportSize;
        static bool SingletonCreated;
        static Lock Texture = new Lock();
        static Lock Shader = new Lock();

        public string Name => "DHS Hall of Fame";

        public ApplicationType Type => ApplicationType.OpenGL;
        bool Disposed;
        Graphics Parent;
        bool ChildRunning;
        List<Action> SynchronizedTasks;

        [LatipiumExport]
        public IOpenGLContext RawContext {
            get {
                return Gl;
            }
        }

        [LatipiumExport]
        public RectangleF GlobalPosition {
            get;
            private set;
        }



        [LatipiumExport]
        public IDisposable TextureLock => Texture.Context;

        [LatipiumExport]
        public bool TextureLocked => Texture.Locked;

        [LatipiumExport]
        public IDisposable ShaderLock => Shader.Context;

        [LatipiumExport]
        public bool ShaderLocked => Shader.Locked;

        [LatipiumExport]
        public event Action FrameStart;

        [LatipiumExport]
        public event Action FrameEnd;

        void CheckChildAndThrow() {
            if (ChildRunning) {
                throw new NotSupportedException("Cannot render while a child is rendering");
            }
        }

        [LatipiumExport]
        public void FillRect(Color color, RectangleF rectangle) {
            CheckChildAndThrow();
            Gl.Begin(GlPrimitiveType.Quads);
            Gl.Color4ub(color.R, color.G, color.B, color.A);
            Gl.Vertex2f(rectangle.Left, rectangle.Top);
            Gl.Vertex2f(rectangle.Left, rectangle.Bottom);
            Gl.Vertex2f(rectangle.Right, rectangle.Bottom);
            Gl.Vertex2f(rectangle.Right, rectangle.Top);
            Gl.End();
        }

        [LatipiumExport]
        public void DrawImage(Image image, RectangleF rectangle) {
            CheckChildAndThrow();
            if (image.Disposed) {
                throw new ObjectDisposedException(nameof(image));
            }
            Action render = () => {
                Gl.Begin(GlPrimitiveType.Quads);
                Gl.TexCoord2f(0, 1);
                Gl.Vertex2f(rectangle.Left, rectangle.Top);
                Gl.TexCoord2f(0, 0);
                Gl.Vertex2f(rectangle.Left, rectangle.Bottom);
                Gl.TexCoord2f(1, 0);
                Gl.Vertex2f(rectangle.Right, rectangle.Bottom);
                Gl.TexCoord2f(1, 1);
                Gl.Vertex2f(rectangle.Right, rectangle.Top);
                Gl.End();
            };
            using (image.Context) {
                if (ShaderLocked) {
                    render();
                } else {
                    using (Shaders.TextureShader.Context) {
                        render();
                    }
                }
            }
        }

        public static Point ConvertPoint(PointF point, IGraphics graphics) {
            return new Point((int) ((graphics.GlobalPosition.Left + point.X * graphics.GlobalPosition.Width) * ViewportSize.Width),
                             (int) ((graphics.GlobalPosition.Top + point.Y * graphics.GlobalPosition.Height) * ViewportSize.Height));
        }

        public static PointF ConvertPoint(Point point, IGraphics graphics) {
            return new PointF(((((float) point.X) / (float) ViewportSize.Width) - graphics.GlobalPosition.Left) / graphics.GlobalPosition.Width,
                              ((((float) point.Y) / (float) ViewportSize.Height) - graphics.GlobalPosition.Top) / graphics.GlobalPosition.Height);
        }

        public static Size ConvertSize(SizeF size, IGraphics graphics) {
            return new Size((int) (size.Width * graphics.GlobalPosition.Width * (float) ViewportSize.Width),
                            (int) (size.Height * graphics.GlobalPosition.Height * (float) ViewportSize.Height));
        }

        public static SizeF ConvertSize(Size size, IGraphics graphics) {
            return new SizeF(((float) size.Width) / (graphics.GlobalPosition.Width * (float) ViewportSize.Width),
                             ((float) size.Height) / (graphics.GlobalPosition.Height * (float) ViewportSize.Height));
        }

        public static Rectangle ConvertRectangle(RectangleF rectangle, IGraphics graphics) {
            return new Rectangle(ConvertPoint(new PointF(rectangle.X, rectangle.Y), graphics), ConvertSize(new SizeF(rectangle.Width, rectangle.Height), graphics));
        }

        public static RectangleF ConvertRectangle(Rectangle rectangle, IGraphics graphics) {
            return new RectangleF(ConvertPoint(new Point(rectangle.X, rectangle.Y), graphics), ConvertSize(new Size(rectangle.Width, rectangle.Height), graphics));
        }

        static RectangleF Scale(RectangleF rectangle, float factor) {
            return new RectangleF(rectangle.X * factor, rectangle.Y * factor, rectangle.Width * factor, rectangle.Height * factor);
        }

        [LatipiumExport]
        public RectangleF MeasureString(Font font, string str, float size = 1) {
            return Scale(ConvertRectangle(font.MeasureString(str), this), size);
        }

        [LatipiumExport]
        public void DrawString(Font font, string str, Color color, PointF origin, float size = 1) {
            Gl.Color4ub(color.R, color.G, color.B, color.A);
            Action render = () => {
                font.DrawString(str, ConvertPoint(origin, this), (rect, image) => {
                    DrawImage(image, Scale(ConvertRectangle(rect, this), size));
                });
            };
            if (ShaderLocked) {
                render();
            } else {
                using (Shaders.FontShader.Context) {
                    render();
                }
            }
        }

        [LatipiumExport]
        public IGraphics CreateGraphics(RectangleF rectangle) {
            ChildRunning = true;
            Gl.PushMatrix();
            Gl.Translatef(rectangle.Left, rectangle.Top, 0);
            Gl.Scalef(rectangle.Width, rectangle.Height, 0);
            return new Graphics(this, new RectangleF(GlobalPosition.Left + rectangle.Left * GlobalPosition.Width,
                                                     GlobalPosition.Top + rectangle.Top * GlobalPosition.Height,
                                                     GlobalPosition.Width * rectangle.Width,
                                                     GlobalPosition.Height * rectangle.Height));
        }

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                if (disposing) {
                    if (Parent != null) {
                        Gl.PopMatrix();
                        Parent.ChildRunning = false;
                    }
                }
                Disposed = true;
            }
        }

        [LatipiumExport]
        public void Dispose() {
            Dispose(true);
        }

        void Frame() {
            FrameStart?.Invoke();
            List<Action> tasks = SynchronizedTasks;
            SynchronizedTasks = new List<Action>();
            foreach (Action task in tasks) {
                task();
            }
            FrameEnd?.Invoke();
        }

        [LatipiumExport]
        public void SynchronizedTask(Action action) {
            if (Parent == null) {
                SynchronizedTasks.Add(action);
            } else {
                Parent.SynchronizedTask(action);
            }
        }

        public void Start(IRenderContext ctx) {
            Gl = (IOpenGLContext) ctx;
            AssemblyLoader.LoadAssembly(typeof(Graphics).Assembly);
            AssemblyLoader.Finish();
            Gl.Enable(GlEnableCap.Blend);
            Gl.BlendFunc(GlBlendingFactor.SrcAlpha, GlBlendingFactor.OneMinusSrcAlpha);
            Gl.Clear(GlClearBufferMask.ColorBufferBit);
            Gl.Translatef(-1, -1, 0);
            Gl.Scalef(2, 2, 0);
            int[] viewport = new int[4];
            Gl.GetIntegerv(GlGetPName.Viewport, viewport);
            ViewportSize = new Size(viewport[2], viewport[3]);
            Gl.Input.Window.ViewportResize += (w, h) => ViewportSize = new Size(w, h);
        }

        public void Stop() {
        }

        public Graphics() {
            if (Gl != null) {
                if (SingletonCreated) {
                    throw new NotSupportedException("Singleton has already been created");
                } else {
                    SingletonCreated = true;
                    Gl.Frame += Frame;
                    SynchronizedTasks = new List<Action>();
                }
            }
            GlobalPosition = new RectangleF(0, 0, 1, 1);
        }

        Graphics(Graphics parent, RectangleF globalPosition) {
            Parent = parent;
            GlobalPosition = globalPosition;
        }
    }
}
