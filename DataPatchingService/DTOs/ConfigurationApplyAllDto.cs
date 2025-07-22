// DTOs/ConfigurationApplyAllDto.cs
using DataPatchingService.Configurations;

namespace DataPatchingService.DTOs
{
    public class ConfigurationApplyAllDto
    {
        public EnergyTypeConfig Equipment { get; set; }
        public int LevelId { get; set; }
        public double BenchmarkValue { get; set; }
    }
}