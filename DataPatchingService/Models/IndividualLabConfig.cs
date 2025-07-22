// Models/IndividualLabConfig.cs
using DataPatchingService.Configurations;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    /// <summary>
    /// Model for individual lab tag id configuration
    /// </summary>
    public class IndividualLabConfig
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        public int IndividualLabConfigId { get; set; }
        /// <summary>
        /// lab type
        /// </summary>
        [EnumDataType(typeof(EnergyTypeConfig), ErrorMessage =
        "Invalid equipment. Valid values are 0:DryLab , 1:WetLab,100:All")]
        public LabTypeConfig LabTypeConfig { get; set; }
        /// <summary>
        /// block value
        /// </summary>
        [EnumDataType(typeof(BlockConfig), ErrorMessage =
       "Invalid block. Valid values are 0: W1, 1: W3, 2:W5,3:W6,4:E1,5: E2,6: E3,7:E4,8:E5,9:E6, 100:All")]
        public BlockConfig Block { get; set; }
        /// <summary>
        /// level value
        /// </summary>
        [EnumDataType(typeof(LevelConfig), ErrorMessage =
      "Invalid level. Valid values are 0:Level1, 1:Level2,2:Level3, 3:Level4,4:Level5, 5:Level6,6:Level7, 7:Level8,8:Level9, 9:Level10,100:All")]
        public LevelConfig Level { get; set; }
        /// <summary>
        /// Room number of level
        /// </summary>
        public int RoomNo { get; set; }
        /// <summary>
        /// Name of the lab
        /// </summary>
        public string LabName { get; set; }
        /// <summary>
        /// The TagId relating to the corresponding configuration object
        /// used to store data from this sensor in the
        /// <see cref="SITDataStorage.Contexts.StorageDBContext"></see>.
        /// </summary>
        public int TagId { get; set; }
    }
}