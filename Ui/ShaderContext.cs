using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class ShaderContext : IDisposable {
        bool Disposed;
        Shader Shader;

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                Shader.Graphics.RawContext.UseProgram(0);
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
            Shader.Graphics.RawContext.UseProgram(Shader.ProgramId);
        }
    }
}
