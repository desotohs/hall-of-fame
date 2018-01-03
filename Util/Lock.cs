using System;
using System.Threading;

namespace Com.GitHub.DesotoHS.HallOfFame.Util {
    public class Lock {
        Mutex Mutex;

        public LockContext Context => new LockContext(this);

        public bool Locked {
            get;
            private set;
        }

        public void DoLock() {
            Mutex.WaitOne();
            Locked = true;
        }

        public void Unlock() {
            Mutex.ReleaseMutex();
            Locked = false;
        }

        public Lock() {
            Mutex = new Mutex();
        }
    }
}
