using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Loading {
    public interface ILoadingTask {
        int TotalTasks {
            get;
        }

        int CompletedTasks {
            get;
        }

        void Load();
    }
}
