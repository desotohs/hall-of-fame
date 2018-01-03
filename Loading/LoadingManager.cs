using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Latipium.Core;

namespace Com.GitHub.DesotoHS.HallOfFame.Loading {
    [LatipiumExportClass(0)]
    public class LoadingManager : ILoadingManager {
        List<ILoadingTask> Tasks;
        Dictionary<ILoadingTask, Task> Threads;
        object StartingLock;

        [LatipiumExport]
        public int TotalTasks => Tasks.Select(t => t.TotalTasks).Sum();

        [LatipiumExport]
        public int FinishedTasks => Tasks.Select(t => t.CompletedTasks).Sum();

        [LatipiumExport]
        public event Action LoadingFinished;

        [LatipiumExport]
        public void AddTask(ILoadingTask task) {
            Tasks.Add(task);
            if (Threads.Count > 0) {
                lock (StartingLock) {
                    Task thread = Threads[task] = Task.Run((Action) task.Load);
                    thread.ContinueWith(HandleTaskFinish, task);
                }
            }
        }

        void HandleTaskFinish(Task thread, object state) {
            ILoadingTask task = (ILoadingTask) state;
            Threads.Remove(task);
            if (Threads.Count == 0) {
                LoadingFinished?.Invoke();
            }
        }

        [LatipiumExport]
        public void StartLoading() {
            lock (StartingLock) {
                foreach (ILoadingTask task in Tasks) {
                    Task thread = Threads[task] = Task.Run((Action) task.Load);
                    thread.ContinueWith(HandleTaskFinish, task);
                }
            }
        }

        [LatipiumExport]
        public void WaitFor(ILoadingTask task) {
            lock (StartingLock) {
            }
            if (Threads.ContainsKey(task)) {
                Threads[task].Wait();
            }
        }

        public LoadingManager() {
            Tasks = new List<ILoadingTask>();
            Threads = new Dictionary<ILoadingTask, Task>();
            StartingLock = new object();
        }
    }
}
