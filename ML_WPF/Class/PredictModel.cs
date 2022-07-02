using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_WPF.Class
{
    internal class PredictModel
    {
        public string PredictedLabel_1 { get; set; }
        public string PredictedLabel_2 { get; set; }
        public string PredictedLabel_3 { get; set; }
        public string PredictedLabel_4 { get; set; }
        public float[] PredictedResult_1 { get; set; }
        public float[] PredictedResult_2 { get; set; }
        public float[] PredictedResult_3 { get; set; }
        public float[] PredictedResult_4 { get; set; }
    }
}
