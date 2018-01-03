using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Loading {
    public interface ILoadingManager {
        int TotalTasks {
            get;
        }

        int FinishedTasks {
            get;
        }

        event Action LoadingFinished;
        
        void StartLoading();

        void AddTask(ILoadingTask task);

        void WaitFor(ILoadingTask task);
    }
}
