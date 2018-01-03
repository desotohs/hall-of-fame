using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class Media<T> : IMedia {
        public string Name {
            get;
            private set;
        }

        public byte[] Content {
            get;
            private set;
        }

        public T State;

        public Media(string name, byte[] content, T state = default(T)) {
            Name = name;
            Content = content;
            State = state;
        }
    }
}
