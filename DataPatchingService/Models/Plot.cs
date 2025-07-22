// Models/Plot.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class Plot
    {
        [Key]
        public int PlotId { get; set; }
        public string PlotName { get; set; }
        public List<Block> Blocks { get; set; }
        public List<PopulationTagConfig> PopulationTagConfig { get; set; }
    }
}