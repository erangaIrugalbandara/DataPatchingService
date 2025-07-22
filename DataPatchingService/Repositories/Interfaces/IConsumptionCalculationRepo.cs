// Repositories/Interfaces/IConsumptionCalculationRepo.cs
using DataPatchingService.Configurations;
using DataPatchingService.DTOs;
using DataPatchingService.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPatchingService.Repositories.Interfaces
{
    public interface IConsumptionCalculationRepo
    {
        Task<IList<double>> GetAverageByWeekdayAsync(IList<int> tagIds, DateTime endDate, int numberOfDays);
        Task<double> GetConsumptionDifference(int TagId, DateTime startDate, DateTime endDate);
        Task<TwoMonthViewChartDto> GetLastTwoMonthConsumptionDetails(List<int> tagIds, EnergyTypeConfig type);
        Task<List<ChartData>> GetWeeklyConsumptionDetails(List<int> tagIds, DateTime selectedDate);
        Task<List<ChartData>> GetMonthlyConsumptionDetails(List<int> tagIds, DateTime startDate);
        Task<List<ChartData>> GetYearlyConsumptionDetails(List<int> tagIds, int month, int year);
        Task<List<ChartData>> GetSixMonthConsumptionDetails(List<int> tagIds, int month, int year);
        Tuple<string, double, double> GetTwoMonthPercentageDetails(double lastMonthValue, double monthBeforeLastValue);
        Task<List<int>> GetMeterTagIds(EnergyTypeConfig energyType);
        Task<double> GetTotalConsumptionValue(List<int> tagIds, DateTime start, DateTime end);
        Task<List<int>> GetAveragePersonCountLastSixMonth(List<int> tagId);
        DateTime GetCurrentMonthEnd();
        DateTime GetCurrentYearEnd();
        Task<double> GetConsumptionDifferenceFromStorageDb(int tagId, DateTime startDate, DateTime endDate);
        Task<List<DailyReadingDto>> GetConsumptionDifferenceFromStorageDb(List<int> tagIds, DateTime startDate, DateTime endDate);
        Task<double> GetFirstConsumptionOfDay(int tagId, DateTime Date);
        Task<List<int>> GetCoolingLoadTagsAsync();
    }
}