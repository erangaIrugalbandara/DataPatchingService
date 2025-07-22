// Models/SolarTagConfig.cs
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class SolarTagConfig
    {
        [Key]
        public int SolarTagConfigId { get; set; }
        /// <summary>
        /// Block of solar meter exist
        /// </summary>
        public int BlockId { get; set; }
        /// <summary>
        /// TagId of meter
        /// </summary>
        public int TagId { get; set; }
        public Block Block { get; set; }
    }
}