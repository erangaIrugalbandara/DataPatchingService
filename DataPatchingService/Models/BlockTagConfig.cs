// Models/BlockTagConfig.cs
using DataPatchingService.Configurations;

namespace DataPatchingService.Models
{
    /// <summary>
    /// model for configure tag id to each meter within block with levels
    /// </summary>
    public class BlockTagConfig
    {
        public int BlockTagConfigId { get; set; }
        public EnergyTypeConfig Energy { get; set; }
        public BlockNameConfig BlockName { get; set; }
        public LevelConfig Level { get; set; }
        public int TagId { get; set; }
    }
}
