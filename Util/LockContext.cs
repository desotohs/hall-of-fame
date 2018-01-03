using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Util {
    public class LockContext : IDisposable {
        Lock Lock;
        bool Disposed;

        public void Dispose() {
            if (!Disposed) {
                Disposed = true;
                Lock.Unlock();
            }
        }

        public LockContext(Lock @lock) {
            Lock = @lock;
            Lock.DoLock();
        }
    }
}
