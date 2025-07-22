// DTOs/EquipmentConfigurationDtoInDetails.cs
using DataPatchingService.Configurations;

namespace DataPatchingService.DTOs
{
    public class EquipmentConfigurationDtoInDetails
    {
        public EnergyTypeConfig Equipment { get; set; }
        public string Block { get; set; }
        public string Level { get; set; }
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
        public int TagConfigId { get; set; }
        public int EquipmentConfigId { get; set; }
    }
}