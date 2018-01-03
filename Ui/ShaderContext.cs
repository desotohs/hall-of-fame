using System;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class ShaderContext : LatipiumObject, IDisposable {
        bool Disposed;
        Shader Shader;
        [LatipiumImport]
        public IGraphics Graphics;
        IDisposable ShaderLock;

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                Shader.Graphics.RawContext.UseProgram(0);
                ShaderLock.Dispose();
                Disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }

        public ShaderContext(Shader shader) {
            if (shader.Disposed) {
                throw new ObjectDisposedException(nameof(shader));
            }
            Shader = shader;
            ShaderLock = Graphics.ShaderLock;
            Shader.Graphics.RawContext.UseProgram(Shader.ProgramId);
        }
    }
}
