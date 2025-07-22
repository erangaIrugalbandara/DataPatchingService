using DataPatchingService.Models;
using DataPatchingService.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace DataPatchingService.Services
{
    public class DataPatchService
    {
        private readonly IConsumptionCalculationRepo _consumptionRepo;
        private readonly IConfigDashboard _configRepo;
        private readonly IMeterResetRepo _meterRepo;
        private DateTime _calcTime;

        public DataPatchService(
            IConsumptionCalculationRepo consumptionRepo,
            IConfigDashboard configRepo,
            IMeterResetRepo meterRepo)
        {
            _consumptionRepo = consumptionRepo;
            _configRepo = configRepo;
            _meterRepo = meterRepo;
        }

        public async Task ExecuteDataPatchAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                _calcTime = startTime.AddDays(1);
                Console.WriteLine("Data patch started.");

                int totalDays = (int)(endTime - startTime).TotalDays;
                int currentDay = 0;

                while (_calcTime <= endTime)
                {
                    currentDay++;
                    var progressPercentage = (currentDay * 100) / totalDays;

                    Console.WriteLine($"Processing day {currentDay}/{totalDays} ({progressPercentage}%) - {_calcTime.AddDays(-1):yyyy-MM-dd}");
                    Console.WriteLine($"Processing data for {_calcTime.AddDays(-1):yyyy-MM-dd}");

                    var tagIds = await _configRepo.GetAllTagIds();
                    Console.WriteLine($"Found {tagIds.Count} tags to process");

                    foreach (var tag in tagIds)
                    {
                        await CalculateDailyConsumptionValues(tag);
                    }

                    Console.WriteLine($"Meter Reset Service patched data for {_calcTime.AddDays(-1):yyyy-MM-dd}");
                    _calcTime = _calcTime.AddDays(1);
                }

                Console.WriteLine("Data patch ended successfully.");
                Console.WriteLine($"\nData patch completed successfully! Processed {totalDays} days.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during data patch execution: {ex.Message}");
                throw;
            }
        }

        private async Task CalculateDailyConsumptionValues(int tagId)
        {
            try
            {
                DateTime todayStart;
                if (_calcTime.TimeOfDay == TimeSpan.Zero)
                {
                    DateTime today = _calcTime.AddDays(-1);
                    todayStart = new DateTime(today.Year, today.Month, today.Day);
                }
                else
                {
                    todayStart = new DateTime(_calcTime.Year, _calcTime.Month, _calcTime.Day);
                }

                DateTime todayEnd = new DateTime(todayStart.AddDays(1).Year, todayStart.AddDays(1).Month, todayStart.AddDays(1).Day);

                var existingData = await _meterRepo.GetDailyConsumptionValueAsync(tagId, todayStart);
                if (existingData != null)
                {
                    existingData.Value = await GetTodayDataDifferenceAsync(tagId, todayStart, todayEnd);
                    await _meterRepo.SaveOrUpdateDailyConsumptionValueAsync(existingData, true);
                }
                else
                {
                    var newDailyConsumption = new DailyMeterReading
                    {
                        TagId = tagId,
                        Value = await GetTodayDataDifferenceAsync(tagId, todayStart, todayEnd),
                        TimeStamp = todayStart
                    };
                    await _meterRepo.SaveOrUpdateDailyConsumptionValueAsync(newDailyConsumption, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating daily consumption for TagId {tagId} on {_calcTime.AddDays(-1):yyyy-MM-dd}: {ex.Message}");
            }
        }
     
        private async Task<double> GetTodayDataDifferenceAsync(int tagId, DateTime todayStart, DateTime todayEnd)
        {
            try
            {
                double difference = 0;
                double startValue = 0;

                difference = await _consumptionRepo.GetConsumptionDifferenceFromStorageDb(tagId, todayStart, todayEnd);

                if (difference < 0)
                {
                    startValue = await _consumptionRepo.GetFirstConsumptionOfDay(tagId, todayStart);
                    difference = (int)Math.Pow(10, Math.Floor(Math.Log10(startValue) + 1)) + difference;
                }

                if ((await _consumptionRepo.GetCoolingLoadTagsAsync()).Contains(tagId))
                {
                    return difference * 0.2843451361;
                }
                else
                {
                    return difference;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"CalculateDifferenceValues Error for TagId {tagId}: {e.Message}");
                return 0;
            }
        }
    }
}