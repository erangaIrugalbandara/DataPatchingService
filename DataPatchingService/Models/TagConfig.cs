// Models/TagConfig.cs
using DataPatchingService.Configurations;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace DataPatchingService.Models
{
    public class TagConfig
    {
        [Key]
        public int TagConfigId { get; set; }
        public int TagId { get; set; }
        public string EquipmentCode { get; set; }
        public EnergyTypeConfig Equipment { get; set; }
        public int LevelId { get; set; }
        public EquipmentConfig EquipmentConfig { get; set; }
        public Level Level { get; set; }
    }
}