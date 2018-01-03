using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class ActivityPicture<T> : IActivityPicture {
        public string Name {
            get;
            private set;
        }

        public byte[] Picture {
            get;
            private set;
        }

        public string Description {
            get;
            private set;
        }

        public T State;

        public ActivityPicture(string name, byte[] picture, string description, T state = default(T)) {
            Name = name;
            Picture = picture;
            Description = description;
            State = state;
        }
    }
}
