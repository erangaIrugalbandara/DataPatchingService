// DTOs/EquipmentConfigurationDto.cs
using DataPatchingService.Configurations;

namespace DataPatchingService.DTOs
{
    public class EquipmentConfigurationDto
    {
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
