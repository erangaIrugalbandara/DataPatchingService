// DTOs/Response/PeriodChartDto.cs
using DataPatchingService.Configurations;

namespace DataPatchingService.DTOs.Response
{
    public class PeriodChartDto
    {
        public double Consumption { get; set; }
        public string Period { get; set; }
    }

    public class TotalConsmptionViewDto
    {
        public double Consumption { get; set; }
        public EnergyTypeConfig EnergyType { get; set; }
    }
}
