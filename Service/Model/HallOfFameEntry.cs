using System;
using System.Collections.Generic;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class HallOfFameEntry<T> : IHallOfFameEntry {
        public string Name {
            get;
            private set;
        }

        public int Year {
            get;
            private set;
        }

        public byte[] Picture {
            get;
            private set;
        }

        public string Essay {
            get;
            private set;
        }

        public IEnumerable<IMedia> Media {
            get;
            private set;
        }

        public T State;

        public HallOfFameEntry(string name, int year, byte[] picture, string essay, IEnumerable<IMedia> media, T state = default(T)) {
            Name = name;
            Year = year;
            Picture = picture;
            Essay = essay;
            Media = media;
            State = state;
        }

        public HallOfFameEntry(string name, int year, byte[] picture, string essay, params IMedia[] media) : this(name, year, picture, essay, media, default(T)) {
        }

        public HallOfFameEntry(string name, int year, byte[] picture, string essay, T state, params IMedia[] media) : this(name, year, picture, essay, media, state) {
        }
    }
}
