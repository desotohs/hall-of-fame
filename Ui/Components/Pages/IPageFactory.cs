using System;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui.Components.Pages {
    public interface IPageFactory {
        Page CreatePage(IPageInfo page);
    }
}
