using System;
using CsvHelper.Configuration.Attributes;

namespace ML_WPF.Class
{
    internal class CsvFull
    {
        [Index(0)]
        public string? Div { get; set; }
        [Index(1)]
        public string? Date { get; set; }
        [Index(2)]
        public string? HomeTeam { get; set; }
        [Index(3)]
        public string? AwayTeam { get; set; }
        [Index(4)]
        public int FTHG { get; set; }
        [Index(5)]
        public int FTAG { get; set; }
        [Index(6)]
        public string? FTR { get; set; }
        [Index(7)]
        public string? Referee { get; set; }
        [Index(8)]
        public int HS { get; set; }
        [Index(9)]
        public int AS { get; set; }
    }
}
