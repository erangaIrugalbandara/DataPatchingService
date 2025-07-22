// Models/EquipmentConfig.cs
using DataPatchingService.Configurations;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class EquipmentConfig
    {
        [Key]
        public int EquipmentConfigId { get; set; }
        public int TagConfigId { get; set; }
        public ModeConfig Mode { get; set; }
        public bool IsEnabled { get; set; }
        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }
        public TagConfig TagConfig { get; set; }
    }
}
