// DTOs/Response/PlotViewDtos.cs
using DataPatchingService.Configurations;
using System.Collections.Generic;

namespace DataPatchingService.DTOs.Response
{
    public class PlotTotalViewDto
    {
        public double Consumption { get; set; }
        public PlotConfig Plot { get; set; }
    }

    public class BlockDistributionViewDto
    {
        public double Consumption { get; set; }
        public string Block { get; set; }
        public string BlockName { get; set; }
    }

    public class LevelConsumptionDto
    {
        public double Consumption { get; set; }
        public string Level { get; set; }
    }

    public class LevelEnergyViewDto
    {
        public string Period { get; set; }
        public List<LevelConsumptionDto> Levels { get; set; }
    }

    public class LevelEnergyChartViewDto
    {
        public IEnumerable<string> Period { get; set; }
        public List<LevelsConsumptionData> LevelData { get; set; }
    }

    public class LevelsConsumptionData
    {
        public string Level { get; set; }
        public List<double> Values { get; set; }
    }
}
