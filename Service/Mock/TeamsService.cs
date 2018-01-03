using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class TeamsService : ITeamsService {
        static readonly IEnumerable<IGrouping<int, IActivityPicture>> Teams = new [] {
            new Tuple<int, IActivityPicture>(2006, new ActivityPicture<object>("Girls Cross Country", File.ReadAllBytes("MockResources/StateChampions0.jpg"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ornare semper elit ut ullamcorper. Mauris ultricies ante tristique ipsum accumsan imperdiet. Aenean tellus lacus, volutpat nec vestibulum sed, feugiat eget metus. Suspendisse sed odio tortor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec augue et tellus scelerisque lobortis in quis nulla. Nullam interdum ligula cursus massa consectetur ullamcorper. Nulla et tortor quam. Sed sed libero ut orci volutpat volutpat ut quis diam. Fusce pellentesque non nisl eget efficitur. Phasellus accumsan ac nunc ac aliquam. Sed laoreet magna vitae rhoncus malesuada. Aenean tristique, felis a volutpat suscipit, mauris dolor vestibulum est, et elementum est nulla eget sem. Etiam nec rhoncus massa. Vivamus ornare ligula et ipsum sodales gravida. Curabitur finibus porta dolor sed semper.")),
            new Tuple<int, IActivityPicture>(1998, new ActivityPicture<object>("Softball", File.ReadAllBytes("MockResources/StateChampions1.jpg"), "Donec id fringilla nulla. Ut elementum sapien nec leo placerat, ut commodo eros gravida. Ut ac felis nisi. Aliquam condimentum cursus elit, sit amet dignissim mauris tristique a. Duis venenatis ex a neque semper dictum. Vivamus lectus leo, sodales vel elit ullamcorper, euismod fermentum augue. Maecenas eu sem nec dui lacinia iaculis ornare a elit. Aenean mattis, erat et pulvinar viverra, velit sem sagittis nisl, eu venenatis augue lacus sed urna. Sed diam diam, facilisis id tempus id, bibendum in velit. Quisque interdum suscipit lobortis. Fusce ullamcorper ipsum ligula, id eleifend risus tincidunt consectetur. Praesent eleifend metus nec erat mattis, eu blandit justo lobortis.")),
            new Tuple<int, IActivityPicture>(2006, new ActivityPicture<object>("Scholars Bowl", File.ReadAllBytes("MockResources/StateChampions2.jpg"), "Suspendisse potenti. Aenean varius mi ipsum, ut eleifend ligula interdum eu. Sed consectetur euismod ultrices. Duis eget porta ante. Curabitur aliquet turpis eget rhoncus rhoncus. Fusce hendrerit nunc quis libero commodo, in finibus urna finibus. Aliquam erat volutpat. Nunc condimentum fringilla laoreet. Donec rhoncus neque quis orci suscipit, ut pretium eros varius."))
        }.GroupBy(t => t.Item1, t => t.Item2);

        [LatipiumExport]
        public IEnumerable<IGrouping<int, IActivityPicture>> GetTeams(IPageInfo page) {
            switch (((PageInfo<int>) page).State) {
                case 5:
                    return Teams;
                default:
                    throw new ArgumentException("Invalid page");
            }
        }
    }
}
