using System;
using System.Collections.Generic;
using Com.GitHub.DesotoHS.HallOfFame.Service.Model;

namespace Com.GitHub.DesotoHS.HallOfFame.Service.Mock {
    public class AllTimeRecordsService : IAllTimeRecordsService {
        static readonly ISportRecords[] AllTimeRecords = new ISportRecords[] {
            new SportRecords<object>("Football", new SportsRecord<object>("Rushing Yards", new ISportsRecordHolder[] {
                new SportsRecordHolder<object>("Michael Allen", "1611", "2001", 12),
                new SportsRecordHolder<object>("Jeff Bowen", "975", "2010", 12),
                new SportsRecordHolder<object>("Michael Allen", "943", "2000", 11),
                new SportsRecordHolder<object>("Ryan Hicks", "923", "2010", 11),
                new SportsRecordHolder<object>("Leif Goleman", "824", "2003", 12),
                new SportsRecordHolder<object>("Bryce Mohl", "734", "2017", 12),
                new SportsRecordHolder<object>("Bryce Mohl", "732", "2016", 11),
                new SportsRecordHolder<object>("Leo Oplotnik", "716", "2017", 12),
                new SportsRecordHolder<object>("Neil Erisman", "699", "2003", 10),
                new SportsRecordHolder<object>("Dylan Burford", "697", "2009", 12)
            }, new ISportsCareerRecordHolder[] {
                new SportsCareerRecordHolder<object>("Nathan Weimer", "3,259", 1986, 1989),
                new SportsCareerRecordHolder<object>("Michael Allen", "2,554", 1999, 2002),
                new SportsCareerRecordHolder<object>("Rick Fisher", "2,551", 1977, 1980),
                new SportsCareerRecordHolder<object>("Darrin O'Rourke", "1,813", 1987, 1990),
                new SportsCareerRecordHolder<object>("Bob Smith", "1,547", 1984, 1987),
                new SportsCareerRecordHolder<object>("Steve Davis", "1,495", 1975, 1978),
                new SportsCareerRecordHolder<object>("Bryce Mohl", "1,452", 2016, -1),
                new SportsCareerRecordHolder<object>("Mason Clark", "1,366", 2014, 2016),
                new SportsCareerRecordHolder<object>("Dylan Burford", "1,315", 2006, 2009),
                new SportsCareerRecordHolder<object>("Ryan Hicks", "1,276", 2008, 2011)
            }, new ISportsTeamRecord[] {
                new SportsTeamRecord<object>("Anderson Co.", "426", "2007"),
                new SportsTeamRecord<object>("Piper", "425", "2003"),
                new SportsTeamRecord<object>("St. James", "395", "2011")
            }, new ISportsSeasonRecord[] {
                new SportsSeasonRecord<object>("2017", "2,921"),
                new SportsSeasonRecord<object>("2010", "2,828"),
                new SportsSeasonRecord<object>("2016", "2,326")
            }), new SportsRecord<object>("Rushing Average", new ISportsRecordHolder[] {
                new SportsRecordHolder<object>("Darren Winans", "9.2", "2016", 11),
                new SportsRecordHolder<object>("Alex Pruss", "8.1", "2011", 11),
                new SportsRecordHolder<object>("Trevor Watts", "8.1", "2017", 12)
            }, new ISportsCareerRecordHolder[] {
                new SportsCareerRecordHolder<object>("Darren Winans", "8.1", -1, -1)
            }, new ISportsTeamRecord[] {
                new SportsTeamRecord<object>("Louisburg", "10.2", "2017"),
                new SportsTeamRecord<object>("St. James", "9.9", "2011")
            }, new ISportsSeasonRecord[] {
                new SportsSeasonRecord<object>("2017", "6.1")
            }))
        };

        public IEnumerable<ISportRecords> GetRecords(IPageInfo page) {
            switch (((PageInfo<int>) page).State) {
                case 2:
                    return AllTimeRecords;
                default:
                    throw new ArgumentException("Invalid page");
            }
        }
    }
}
