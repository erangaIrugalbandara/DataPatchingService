// Models/EquipmentConfigLog.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class EquipmentConfigLog
    {
        /// <summary>
        /// primary key of the model
        /// </summary>
        [Key]
        public int EquipmentConfigLogId { get; set; }

        /// <summary>
        /// last updated value of meter
        /// </summary>
        public double UpdatedValue { get; set; }
        /// <summary>
        /// person name who updated the value
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Time of updated value
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// FK 
        /// </summary>
        public int TagConfigId { get; set; }
        // Required reference navigation to principal
        public TagConfig TagConfig { get; set; }
        /// <summary>
        ///
        /// <summary>
        /// Changed value of particular day
        /// </summary>
        public int Day { get; set; }
    }
}