using System;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components {
    public class VideoBackground : Component {
        [LatipiumImport("BackgroundVideoService")]
        public IBackgroundVideoService Service;
    }
}
