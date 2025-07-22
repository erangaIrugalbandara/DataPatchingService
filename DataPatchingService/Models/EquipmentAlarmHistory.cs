// Models/EquipmentAlarmHistory.cs
using DataPatchingService.Configurations;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class EquipmentAlarmHistory
    {
        /// <summary>
        /// primary key of the model
        /// </summary>
        [Key]
        public int EquipmentAlarmHistoryId { get; set; }
        /// <summary>
        /// status type of each equipment
        /// </summary>
        [EnumDataType(typeof(StatusConfig), ErrorMessage =
      "Invalid status. Valid values are 1: Alarm, 2: Acknowledged")]
        public StatusConfig Status { get; set; }
        /// <summary>
        /// exceeded value of meter
        /// </summary>
        public double DetectedValue { get; set; }
        /// <summary>
        /// thresold value of the day
        /// </summary>
        public double Benchmark { get; set; }
        /// <summary>
        /// Time of alarm triggered
        /// </summary>
        public DateTime AlarmTime { get; set; }
        /// <summary>
        /// Time of acknowledged meter
        /// </summary>
        public DateTime HistoryCreatedTime { get; set; }
        /// <summary>
        /// FK 
        /// </summary>
        public int TagConfigId { get; set; }
        // Required reference navigation to principal
        public TagConfig TagConfig { get; set; }
    }
}