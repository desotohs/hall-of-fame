using System;
using Com.GitHub.ZachDeibert.GraphicsCore;
using SharpFont;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Glyph : IDisposable {
        bool Disposed;
        public readonly Fixed26Dot6 BearingX;
        public readonly Fixed26Dot6 BearingY;
        public readonly Fixed26Dot6 Advance;
        public readonly Fixed26Dot6 Width;
        public readonly Fixed26Dot6 Height;
        public readonly Image Image;

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                if (disposing) {
                    Image?.Dispose();
                }
                Disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }

        public Glyph(Face face, uint glyphIndex) {
            face.LoadGlyph(glyphIndex, LoadFlags.Default, LoadTarget.Normal);
            BearingX = face.Glyph.Metrics.HorizontalBearingX;
            BearingY = face.Glyph.Metrics.HorizontalBearingY;
            Advance = face.Glyph.Metrics.HorizontalAdvance;
            Width = face.Glyph.Metrics.Width;
            Height = face.Glyph.Metrics.Height;
            face.Glyph.RenderGlyph(RenderMode.Normal);
            if (face.Glyph.Bitmap.Buffer != IntPtr.Zero) {
                byte[] misaligned = face.Glyph.Bitmap.BufferData;
                byte[] aligned;
                if (face.Glyph.Bitmap.Width % 4 == 0) {
                    aligned = misaligned;
                } else {
                    int diff = 4 - (face.Glyph.Bitmap.Width % 4);
                    aligned = new byte[(face.Glyph.Bitmap.Width + diff) * face.Glyph.Bitmap.Rows];
                    int misalignedI = 0;
                    int alignedI = 0;
                    for (int i = 0; i < face.Glyph.Bitmap.Rows; ++i) {
                        Array.Copy(misaligned, misalignedI, aligned, alignedI, face.Glyph.Bitmap.Width);
                        misalignedI += face.Glyph.Bitmap.Width;
                        alignedI += face.Glyph.Bitmap.Width + diff;
                    }
                }
                Image = new Image(aligned, face.Glyph.Bitmap.Width, face.Glyph.Bitmap.Rows, GlPixelFormat.Alpha);
            }
        }
    }
}
