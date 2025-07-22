// Models/Level.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; }
        public List<TagConfig> Tags { get; set; }
    }
}
