using System;
using Com.GitHub.ZachDeibert.GraphicsCore;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class ImageContext : IDisposable {
        bool Disposed;
        Image Image;

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                Image.Graphics.RawContext.BindTexture(GlTextureTarget.Texture2d, 0);
                Disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }

        public ImageContext(Image image) {
            if (image.Disposed) {
                throw new ObjectDisposedException(nameof(image));
            }
            Image = image;
            Image.Graphics.RawContext.BindTexture(GlTextureTarget.Texture2d, Image.TextureId);
        }
    }
}
