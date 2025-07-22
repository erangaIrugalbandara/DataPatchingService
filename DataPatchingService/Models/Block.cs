// Models/Block.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace DataPatchingService.Models
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string BlockFullName { get; set; }
        public int PlotId { get; set; }
        public Plot Plot { get; set; }
        public List<Level> Levels { get; set; }
    }
}
