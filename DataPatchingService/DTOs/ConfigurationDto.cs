// DTOs/ConfigurationDto.cs
using DataPatchingService.Configurations;

namespace DataPatchingService.DTOs
{
    public class ConfigurationDto
    {
        public BlockConfig Block { get; set; }
        public LevelConfig Level { get; set; }
        public EnergyTypeConfig Equipment { get; set; }
        public string EquipmentCode { get; set; }
        public ModeConfig Mode { get; set; }
        public bool IsEnabled { get; set; }
        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }
    }
}