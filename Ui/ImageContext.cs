using System;
using Com.GitHub.ZachDeibert.GraphicsCore;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class ImageContext : LatipiumObject, IDisposable {
        bool Disposed;
        Image Image;
        [LatipiumImport]
        public IGraphics Graphics;
        IDisposable TextureLock;

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                Image.Graphics.RawContext.BindTexture(GlTextureTarget.Texture2d, 0);
                TextureLock.Dispose();
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
            TextureLock = Graphics.TextureLock;
            Image.Graphics.RawContext.BindTexture(GlTextureTarget.Texture2d, Image.TextureId);
        }
    }
}
