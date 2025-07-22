using DataPatchingService.Models;
using System;

namespace DataPatchingService.Models
{
    public class DailyMeterReading
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public double Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}