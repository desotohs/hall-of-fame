using System;
using System.Collections.Generic;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class SportRecords<T> : ISportRecords {
        public string Name {
            get;
            private set;
        }

        public IEnumerable<ISportsRecord> Records {
            get;
            private set;
        }

        public T State;

        public SportRecords(string name, IEnumerable<ISportsRecord> records, T state = default(T)) {
            Name = name;
            Records = records;
            State = state;
        }

        public SportRecords(string name, params ISportsRecord[] records) : this(name, records, default(T)) {
        }

        public SportRecords(string name, T state, params ISportsRecord[] records) : this(name, records, state) {
        }
    }
}
