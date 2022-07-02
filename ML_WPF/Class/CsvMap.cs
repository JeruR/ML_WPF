using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_WPF.Class
{
    internal class CsvMap: ClassMap<Csv>
    {
        public CsvMap()
        {
            Map(p => p.Div).Index(0);
            Map(p => p.Date).Index(1);
            Map(p => p.HomeTeam).Index(2);
            Map(p => p.AwayTeam).Index(3);
            Map(p => p.FTAG).Index(4);
            Map(p => p.HS).Index(5);
            Map(p => p.AS).Index(6);
        }
    }
}
