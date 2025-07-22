// DTOs/DailyReadingDto.cs
namespace DataPatchingService.DTOs
{
    public class DailyReadingDto
    {
        public int TagId { get; set; }
        public double DayFirstReading { get; set; }
        public double DayDifference { get; set; }
    }
}