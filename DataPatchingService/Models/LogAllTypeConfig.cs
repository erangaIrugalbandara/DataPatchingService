// Models/LogAllTypeConfig.cs
using DataPatchingService.Configurations;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    /// <summary>
    /// Table to track All type configuration updates or creation logs
    /// </summary>
    public class LogAllTypeConfig
    {
        [Key]
        public int LogAllTypeConfigId { get; set; }
        public string UserName { get; set; }
        public int LevelId { get; set; }
        public string EquipmentCode { get; set; }
        public EnergyTypeConfig Equipment { get; set; }
        public double UpdatedValue { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int Day { get; set; }
        public Level Level { get; set; }
    }
}