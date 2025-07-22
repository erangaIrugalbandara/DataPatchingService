// Models/IndividualLabTagConfig.cs
using DataPatchingService.Configurations;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    public class IndividualLabTagConfig
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        public int IndividualLabTagConfigId { get; set; }
        /// <summary>
        /// lab type
        /// </summary>
        [EnumDataType(typeof(EnergyTypeConfig), ErrorMessage =
        "Invalid equipment. Valid values are 0:DryLab , 1:WetLab,100:All")]
        public LabTypeConfig LabTypeConfig { get; set; }

        public int LevelId { get; set; }
        /// <summary>
        /// Room number of level
        /// </summary>
        public string RoomNo { get; set; }
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
        public Level Level { get; set; }
    }
}