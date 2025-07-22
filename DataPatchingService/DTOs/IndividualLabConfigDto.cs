// DTOs/IndividualLabConfigDto.cs
using DataPatchingService.Configurations;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.DTOs
{
    public class IndividualLabConfigDto
    {
        /// <summary>
        /// lab type
        /// </summary>
        [EnumDataType(typeof(EnergyTypeConfig), ErrorMessage =
        "Invalid equipment. Valid values are 0:DryLab , 1:WetLab,100:All")]
        public LabTypeConfig LabTypeConfig { get; set; }

        /// <summary>
        /// Room number of level
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// Name of the lab
        /// </summary>
        public string LabName { get; set; }

        public string Block { get; set; }
        public string Level { get; set; }
    }
}