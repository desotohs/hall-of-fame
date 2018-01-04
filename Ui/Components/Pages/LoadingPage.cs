using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Loading;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public class LoadingPage : Component {
        const float Padding = 0.1f;
        const float Height = 0.025f;
        const float YMin = 0.5f - Height / 2;
        const float Width = 1 - 2 * Padding;
        static readonly TimeSpan FrameTime = TimeSpan.FromSeconds(1.0 / 60.0);
        [LatipiumImport]
        public ILoadingManager LoadingManager;
        Font Font;
        Image Image;

        protected override void Dispose(bool disposing) {
            if (!Disposed) {
                if (disposing) {
                    Font.Dispose();
                    Image.Dispose();
                }
                Disposed = true;
            }
        }

        public override void Draw(IGraphics g) {
            int total = LoadingManager.TotalTasks;
            int finished = LoadingManager.FinishedTasks;
            float ratio = ((float) finished) / (float) total;
            g.FillRect(Color.Green, new RectangleF(Padding, YMin, ratio * Width, Height));
            string label = string.Format("{0} / {1}", finished, total);
            RectangleF bounds = g.MeasureString(Font, label);
            g.DrawString(Font, label, Color.White, new PointF(0.5f - bounds.Width / 2, 0.5f - bounds.Height / 2));
            Task.Delay(FrameTime).ContinueWith(t => Invalidate());
        }

        public override void DrawBackground(IGraphics g) {
            g.DrawImage(Image, new RectangleF(0, 0, 1, 1));
        }

        public LoadingPage() {
            using (MemoryStream memory = new MemoryStream()) {
                using (Stream stream = typeof(LoadingPage).Assembly.GetManifestResourceStream("hall-of-fame.Ui.UbuntuMono-R.ttf")) {
                    stream.CopyTo(memory);
                }
                Font = new Font(memory.ToArray(), 20);
            }
            Font.LoadOnly = new uint[] { ' ', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Font.Load();
            using (MemoryStream memory = new MemoryStream()) {
                using (Stream stream = typeof(LoadingPage).Assembly.GetManifestResourceStream("hall-of-fame.Ui.Loading.png")) {
                    stream.CopyTo(memory);
                }
                Image = new Image(memory.ToArray());
            }
        }
    }
}
