using System;
using System.Drawing;
using Com.GitHub.ZachDeibert.GraphicsCore;
using Com.Latipium.Core;
using Com.Latipium.Core.Discovery;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    [Application, LatipiumExportClass("Graphics")]
    public class Graphics : IApplication, IGraphics {
        static IOpenGLContext Gl;
        static bool SingletonCreated;

        public string Name => "DHS Hall of Fame";

        public ApplicationType Type => ApplicationType.OpenGL;
        bool Disposed;
        Graphics Parent;
        bool ChildRunning;

        [LatipiumExport]
        public IOpenGLContext RawContext {
            get {
                return Gl;
            }
        }

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
            using (Shaders.TextureShader.Context) {
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
            }
        }

        [LatipiumExport]
        public IGraphics CreateGraphics(RectangleF rectangle) {
            ChildRunning = true;
            Gl.PushMatrix();
            Gl.Translatef(rectangle.Left, rectangle.Top, 0);
            Gl.Scalef(rectangle.Width, rectangle.Height, 0);
            return new Graphics(this);
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
            FrameEnd?.Invoke();
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
                }
            }
        }

        Graphics(Graphics parent) {
            Parent = parent;
        }
    }
}
