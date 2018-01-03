using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public class PageInfo<T> : IPageInfo {
        public string Title {
            get;
            private set;
        }

        public PageType Type {
            get;
            private set;
        }

        public byte[] ButtonIcon {
            get;
            private set;
        }

        public T State;

        public PageInfo(string title, PageType type, byte[] buttonIcon, T state = default(T)) {
            Title = title;
            Type = type;
            ButtonIcon = buttonIcon;
            State = state;
        }
    }
}
