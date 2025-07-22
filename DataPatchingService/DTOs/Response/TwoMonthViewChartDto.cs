// DTOs/Response/TwoMonthViewChartDto.cs
using DataPatchingService.Configurations;
using System.Collections.Generic;

namespace DataPatchingService.DTOs.Response
{
    public class TwoMonthViewChartDto
    {
        public EnergyTypeConfig EnergyType { get; set; }
        public List<PeriodChartDto> ChartData { get; set; }
        public string ConsumptionStatus { get; set; }
        public double ConsumptionPercentage { get; set; }
        public double DifferenceValue { get; set; }
    }
}