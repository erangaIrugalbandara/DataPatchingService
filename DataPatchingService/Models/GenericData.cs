// Models/GenericData.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DataPatchingService.Models
{
    /// <summary>
    /// Generic class for data to be stored
    /// </summary>
    /// <typeparam name="T">The data type of the stored values</typeparam>
    public class GenericData<T>
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Value of the entry
        /// </summary>
        [Required]
        public T Value { get; set; }
        /// <summary>
        /// TagID of the entry corresponding to the ID
        /// of the DataPointConfig
        /// </summary>
        public int TagId { get; set; }
        /// <summary>
        /// Timestamp for the entry
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Data quality parameter
        /// </summary>
        public uint Quality { get; set; }
    }
}