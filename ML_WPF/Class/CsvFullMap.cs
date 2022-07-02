using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_WPF.Class
{
    internal class CsvFullMap : ClassMap<CsvFull>
    {
        public CsvFullMap()
        {
            Map(p => p.Div).Index(0);
            Map(p => p.Date).Index(1);
            Map(p => p.HomeTeam).Index(2);
            Map(p => p.AwayTeam).Index(3);
            Map(p => p.FTHG).Index(4);
            Map(p => p.FTAG).Index(5);
            Map(p => p.FTR).Index(6);
            Map(p => p.Referee).Index(7);
            Map(p => p.HS).Index(8);
            Map(p => p.AS).Index(9);
        }
    }
}
