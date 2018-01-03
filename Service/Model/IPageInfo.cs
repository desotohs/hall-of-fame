using System;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Model {
    public interface IPageInfo {
        string Title {
            get;
        }

        PageType Type {
            get;
        }

        byte[] ButtonIcon {
            get;
        }
    }
}
