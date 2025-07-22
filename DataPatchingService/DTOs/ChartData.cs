// DTOs/ChartData.cs
using System;
using System.Collections.Generic;

namespace DataPatchingService.DTOs.Response
{
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
        public DateTime Time { get; set; }
    }

    public class ChartDataSixMonth
    {
        public List<ChartData> Chart1 { get; set; }
        public List<int> Chart2 { get; set; }
    }
}