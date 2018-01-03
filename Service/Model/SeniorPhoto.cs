using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SeniorPhoto<T> : ISeniorPhoto {
        public string Name {
            get;
            private set;
        }

        public byte[] Picture {
            get;
            private set;
        }

        public T State;

        public SeniorPhoto(string name, byte[] picture, T state = default(T)) {
            Name = name;
            Picture = picture;
            State = state;
        }
    }
}
