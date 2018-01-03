using System;
using System.Threading;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Loading {
    public class TestTask : LatipiumObject, ILoadingTask {
        public int TotalTasks {
            get;
            private set;
        }

        public int CompletedTasks {
            get;
            private set;
        }

        TimeSpan TaskTime;

        [LatipiumImport]
        public ILoadingManager LoadingManager;

        public void Load() {
            for (CompletedTasks = 0; CompletedTasks < TotalTasks; ++CompletedTasks) {
                Thread.Sleep(TaskTime);
            }
        }

        public TestTask(TimeSpan span, int tasks) {
            TotalTasks = tasks;
            TaskTime = span / tasks;
            LoadingManager.AddTask(this);
        }
    }
}
