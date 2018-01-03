using System;
using System.Collections.Generic;
using System.IO;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class HallOfFameService : IHallOfFameService {
        static readonly IHallOfFameEntry[] HallOfFame = new IHallOfFameEntry[] {

        };
        static readonly IHallOfFameEntry[] StateChampions = new IHallOfFameEntry[] {
            new HallOfFameEntry<object>("Girls Cross Country", 2006, File.ReadAllBytes("MockResources/StateChampions0.jpg"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque in diam feugiat, ornare mauris id, sodales turpis. Phasellus viverra magna quis ultricies euismod. Curabitur congue pulvinar purus nec cursus. Curabitur bibendum sed massa id tincidunt. Pellentesque ullamcorper faucibus dolor id auctor. Sed viverra, sem a lacinia elementum, metus ipsum convallis dui, eu ultrices odio dui vitae lacus. Curabitur quis venenatis tellus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce fringilla ultrices magna quis blandit. Pellentesque dictum nec risus in malesuada. Etiam vitae diam a sem molestie pharetra. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse ullamcorper luctus tincidunt. Maecenas tortor augue, bibendum sit amet tellus vel, viverra malesuada nibh."),
            new HallOfFameEntry<object>("Softball", 1998, File.ReadAllBytes("MockResources/StateChampions1.jpg"), "Morbi mollis arcu a est venenatis ultricies fringilla in augue. Phasellus nisl diam, maximus non euismod pretium, finibus facilisis sem. Curabitur hendrerit elementum sapien nec varius. Duis sodales facilisis sollicitudin. In non nunc rutrum, ultricies sapien sit amet, sodales sem. Vestibulum mattis, nunc ut malesuada blandit, odio neque mollis erat, non blandit felis est sit amet mauris. Pellentesque interdum nisl non lacus porta, sed hendrerit eros ornare. Curabitur augue tortor, aliquam sit amet turpis non, tempor sodales ipsum. Suspendisse potenti. Suspendisse pulvinar ante dolor, a scelerisque leo suscipit vel. Quisque sit amet elit mi."),
            new HallOfFameEntry<object>("Scholars Bowl", 2012, File.ReadAllBytes("MockResources/StateChampions2.jpg"), "Donec ultrices lorem ornare urna maximus, non efficitur mauris egestas. Morbi congue sagittis tempor. Nunc est enim, imperdiet et ex ut, vestibulum viverra dui. Aenean consequat tortor quis mollis bibendum. Fusce placerat ac nibh a auctor. Nullam fermentum massa et nisl vehicula, nec vehicula purus efficitur. Vestibulum faucibus in libero non tempor. Donec gravida justo id metus ullamcorper consequat. Quisque scelerisque lectus vitae molestie aliquet. Praesent tristique egestas nisi, a congue mauris mollis ut. Pellentesque interdum suscipit ornare. Morbi fermentum augue vel efficitur varius. Aliquam sed velit id ipsum volutpat placerat vitae non velit. In volutpat nisl at lacus ultricies, eget condimentum nibh placerat. Cras tincidunt, diam vitae tempor convallis, leo arcu tempus diam, at tempus diam massa quis felis. Fusce facilisis consectetur orci.")
        };

        public IEnumerable<IHallOfFameEntry> GetEntries(IPageInfo page) {
            switch (((PageInfo<int>) page).State) {
                case 0:
                    return HallOfFame;
                case 1:
                    return StateChampions;
                default:
                    throw new ArgumentException("Invalid page");
            }
        }
    }
}
