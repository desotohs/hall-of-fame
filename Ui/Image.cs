using System;
using System.IO;
using Com.GitHub.ZachDeibert.GraphicsCore;
using Com.Latipium.Core;
using ImageMagick;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Image : LatipiumObject, IDisposable {
        [LatipiumImport]
        public IGraphics Graphics;
        public bool Disposed {
            get;
            private set;
        }
        public uint TextureId {
            get;
            private set;
        }

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                Graphics.RawContext.DeleteTextures(1, new [] { TextureId });
                Disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Image(MagickImage image) {
            byte[] data = image.GetPixels().ToByteArray(0, 0, image.Width, image.Height, "RGBA");
            uint[] textures = new uint[1];
            Graphics.RawContext.GenTextures(1, textures);
            TextureId = textures[0];
            Graphics.RawContext.ActiveTexture(GlTextureUnit.Texture0);
            Graphics.RawContext.BindTexture(GlTextureTarget.Texture2d, TextureId);
            Graphics.RawContext.TexParameteri(GlTextureTarget.Texture2d, GlTextureParameterName.TextureMagFilter, GL.LINEAR);
            Graphics.RawContext.TexParameteri(GlTextureTarget.Texture2d, GlTextureParameterName.TextureMinFilter, GL.LINEAR);
            Graphics.RawContext.TexParameteri(GlTextureTarget.Texture2d, GlTextureParameterName.TextureWrapS, GL.CLAMP_TO_EDGE);
            Graphics.RawContext.TexParameteri(GlTextureTarget.Texture2d, GlTextureParameterName.TextureWrapT, GL.CLAMP_TO_EDGE);
            Graphics.RawContext.TexImage2D(GlTextureTarget.Texture2d, 0, GlInternalFormat.Rgba, image.Width, image.Height, 0, GlPixelFormat.Rgba, GlPixelType.UnsignedByte, data);
            Graphics.RawContext.GenerateMipmap(GlTextureTarget.Texture2d);
        }

        public Image(byte[] data) : this(new MagickImage(data)) {
        }

        public Image(string filename) : this(new MagickImage(filename)) {
        }

        public Image(Stream stream) : this(new MagickImage(stream)) {
        }

        ~Image() {
            Dispose(false);
        }
    }
}
