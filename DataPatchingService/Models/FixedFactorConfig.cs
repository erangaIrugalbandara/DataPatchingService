// Models/FixedFactorConfig.cs
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class FixedFactorConfig
    {
        /// <summary>
        /// Primary Key ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Constant value
        /// </summary>
        public float FixedFactor { get; set; }
        /// <summary>
        /// Duration
        /// </summary>
        public int DurationInDays { get; set; }
    }
}