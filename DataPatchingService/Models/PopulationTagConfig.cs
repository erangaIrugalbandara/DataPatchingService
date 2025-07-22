// Models/PopulationTagConfig.cs
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class PopulationTagConfig
    {
        [Key]
        public int PopulationTagConfigId { get; set; }
        public int TagId { get; set; }
        public int PlotId { get; set; }
        public Plot Plot { get; set; }
    }
}