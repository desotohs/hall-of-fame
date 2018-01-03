using System;
using System.Collections.Generic;
using System.Linq;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    [LatipiumExportClass(ServicePriorities.Mock)]
    public class IndividualHonorsService : IIndividualHonorsService {
        static readonly IEnumerable<IGrouping<int, IIndividualHonor>> IndividualHonors = new [] {
            new Tuple<int, IIndividualHonor>(1977, new IndividualHonor<object>("Han Solo", "Kessel Run", "Han Solo made the Kessel Run in less than twelve parsecs")),
            new Tuple<int, IIndividualHonor>(1977, new IndividualHonor<object>("George Lucas", "Movie Making", "He started the greatest movie ever!")),
            new Tuple<int, IIndividualHonor>(2017, new IndividualHonor<object>("Jar Jar Binks", "Killing Snoke?", "Spoilers..."))
        }.GroupBy(t => t.Item1, t => t.Item2);

        [LatipiumExport]
        public IEnumerable<IGrouping<int, IIndividualHonor>> GetHonors(IPageInfo page) {
            switch (((PageInfo<int>) page).State) {
                default:
                    throw new ArgumentException("Invalid page");
            }
        }
    }
}
