using System;
using System.Text;
using Com.GitHub.ZachDeibert.GraphicsCore;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Shader : LatipiumObject, IDisposable {
        [LatipiumImport]
        public IGraphics Graphics;
        public bool Disposed {
            get;
            private set;
        }
        public uint ProgramId {
            get;
            private set;
        }
        public ShaderContext Context => new ShaderContext(this);

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                Graphics.RawContext.DeleteProgram(ProgramId);
                Disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        uint CompileShader(string source, GlShaderType type) {
            uint shader = Graphics.RawContext.CreateShader(type);
            Graphics.RawContext.ShaderSource(shader, 1, new [] { Encoding.ASCII.GetBytes(source) }, new [] { Encoding.ASCII.GetByteCount(source) });
            Graphics.RawContext.CompileShader(shader);
            int[] result = new int[1];
            Graphics.RawContext.GetShaderiv(shader, GlShaderParameterName.CompileStatus, result);
            if (((GlBoolean) result[0]) == GlBoolean.False) {
                int[] len = new int[1];
                Graphics.RawContext.GetShaderiv(shader, GlShaderParameterName.InfoLogLength, len);
                byte[] log = new byte[len[0]];
                Graphics.RawContext.GetShaderInfoLog(shader, len[0], len, log);
                Console.Error.WriteLine("Unable to compile {0}!", type);
                Console.Error.Write(Encoding.ASCII.GetString(log));
            }
            return shader;
        }

        public Shader(string fragmentShader, string vertexShader, Action<IOpenGLContext, uint> setup = null) {
            Graphics.SynchronizedTask(() => {
                uint fragment = CompileShader(fragmentShader, GlShaderType.FragmentShader);
                uint vertex = CompileShader(vertexShader, GlShaderType.VertexShader);
                ProgramId = Graphics.RawContext.CreateProgram();
                Graphics.RawContext.AttachShader(ProgramId, vertex);
                Graphics.RawContext.AttachShader(ProgramId, fragment);
                Graphics.RawContext.LinkProgram(ProgramId);
                int[] result = new int[1];
                Graphics.RawContext.GetProgramiv(ProgramId, GlProgramPropertyARB.LinkStatus, result);
                if (((GlBoolean) result[0]) == GlBoolean.False) {
                    int[] len = new int[1];
                    Graphics.RawContext.GetProgramiv(ProgramId, GlProgramPropertyARB.InfoLogLength, len);
                    byte[] log = new byte[len[0]];
                    Graphics.RawContext.GetProgramInfoLog(ProgramId, len[0], len, log);
                    Console.Error.WriteLine("Unable to link shader program!");
                    Console.Error.WriteLine(Encoding.ASCII.GetString(log));
                }
                Graphics.RawContext.DetachShader(ProgramId, vertex);
                Graphics.RawContext.DetachShader(ProgramId, fragment);
                Graphics.RawContext.DeleteShader(vertex);
                Graphics.RawContext.DeleteShader(fragment);
                if (setup != null) {
                    using (Graphics.ShaderLock) {
                        Graphics.RawContext.UseProgram(ProgramId);
                        setup(Graphics.RawContext, ProgramId);
                        Graphics.RawContext.UseProgram(0);
                    }
                }
            });
        }

        ~Shader() {
            Dispose(false);
        }
    }
}
