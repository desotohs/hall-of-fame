using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Com.Latipium.Core;
using SharpFont;
using Com.GitHub.DesotoHS.HallOfFame.Loading;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public class Font : LatipiumObject, ILoadingTask, IDisposable {
        public static readonly Library Library = new Library();
        bool Disposed;
        Dictionary<uint, Glyph> Glyphs;
        Face Face;
        [LatipiumImport]
        public ILoadingManager LoadingManager;
        public int TotalTasks {
            get;
            private set;
        }
        public int CompletedTasks {
            get;
            private set;
        }
        public uint[] LoadOnly;

        public static uint[] StringToCodePoints(string str) {
            char[] chars = str.ToCharArray();
            List<uint> codePoints = new List<uint>();
            for (int i = 0; i < chars.Length; ++i) {
                if (char.IsSurrogate(chars[i])) {
                    if (i + 1 >= chars.Length) {
                        throw new InvalidDataException("Surrogate cannot be the last character in a string.");
                    } else {
                        codePoints.Add((uint) char.ConvertToUtf32(chars[i], chars[++i]));
                    }
                } else {
                    codePoints.Add(chars[i]);
                }
            }
            return codePoints.ToArray();
        }

        public void DrawString(uint[] codePoints, Point location, Action<Rectangle, Image> render) {
            Fixed26Dot6 x = location.X;
            foreach (uint codePoint in codePoints) {
                Glyph glyph = Glyphs[codePoint];
                if (glyph.Image != null) {
                    render(new Rectangle((x + glyph.BearingX).ToInt32(), (glyph.BearingY - glyph.Height).ToInt32() + location.Y, glyph.Width.ToInt32(), glyph.Height.ToInt32()), glyph.Image);
                }
                x += glyph.Advance;
            }
        }

        public void DrawString(string str, Point location, Action<Rectangle, Image> render) {
            DrawString(StringToCodePoints(str), location, render);
        }

        public Rectangle MeasureString(uint[] codePoints) {
            Fixed26Dot6 width = 0;
            Fixed26Dot6 top = 0;
            Fixed26Dot6 bottom = 0;
            foreach (uint codePoint in codePoints) {
                Glyph glyph = Glyphs[codePoint];
                if (top < glyph.BearingY) {
                    top = glyph.BearingY;
                }
                if (bottom < glyph.BearingY - glyph.Height) {
                    bottom = glyph.BearingY - glyph.Height;
                }
                width += glyph.Advance;
            }
            return new Rectangle(0, bottom.ToInt32(), width.ToInt32(), (top - bottom).ToInt32());
        }

        public Rectangle MeasureString(string str) {
            return MeasureString(StringToCodePoints(str));
        }

        public void Load() {
            uint glyphIndex;
            if (LoadOnly == null) {
                uint codePoint = Face.GetFirstChar(out glyphIndex);
                do {
                    Glyphs[codePoint] = new Glyph(Face, glyphIndex);
                    codePoint = Face.GetNextChar(codePoint, out glyphIndex);
                    ++CompletedTasks;
                } while (glyphIndex != 0);
            } else {
                TotalTasks = LoadOnly.Length;
                foreach (uint codePoint in LoadOnly) {
                    glyphIndex = Face.GetCharIndex(codePoint);
                    Glyphs[codePoint] = new Glyph(Face, glyphIndex);
                    ++CompletedTasks;
                }
            }
        }

        protected virtual void Dispose(bool disposing) {
            if (!Disposed) {
                if (disposing) {
                    foreach (Glyph glyph in Glyphs.Values) {
                        glyph.Dispose();
                    }
                }
                Disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }

        public Font(Face font, float size = 300, uint dpi = 72) {
            Face = font;
            Face.SetCharSize(0, size, dpi, dpi);
            Glyphs = new Dictionary<uint, Glyph>();
            TotalTasks = Face.GlyphCount;
            LoadingManager.AddTask(this);
        }

        public Font(string path, float size = 300, uint dpi = 72) : this(new Face(Library, path), size, dpi) {
        }

        public Font(byte[] data, float size = 300, uint dpi = 72) : this(new Face(Library, data, 0), size, dpi) {
        }
    }
}
