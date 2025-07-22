// Repositories/SqlConsumptionCalculationRepo.cs - FIXED CONSTRUCTOR
using DataPatchingService.Configurations;
using DataPatchingService.DTOs;
using DataPatchingService.DTOs.Response;
using DataPatchingService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataPatchingService.Repositories
{
    public class ConsumptionCalculationRepo : IConsumptionCalculationRepo
    {
        private readonly string _storageConnectionString;
        private readonly string _systemConnectionString;

        public ConsumptionCalculationRepo(string storageConnectionString, string systemConnectionString)
        {
            _storageConnectionString = storageConnectionString;
            _systemConnectionString = systemConnectionString;
        }

        public async Task<double> GetConsumptionDifferenceFromStorageDb(int tagId, DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(_storageConnectionString))
            {
                await connection.OpenAsync();

                var firstCommand = new SqlCommand(
                    "SELECT TOP 1 Value FROM SingleDataTable WHERE TagId = @TagId AND CAST(TimeStamp AS DATE) = CAST(@StartDate AS DATE) ORDER BY TimeStamp ASC",
                    connection);
                firstCommand.Parameters.AddWithValue("@TagId", tagId);
                firstCommand.Parameters.AddWithValue("@StartDate", startDate.Date);

                var firstReading = 0.0;
                var firstResult = await firstCommand.ExecuteScalarAsync();
                if (firstResult != null && firstResult != DBNull.Value)
                {
                    firstReading = Convert.ToDouble(firstResult);
                }

                var lastCommand = new SqlCommand(
                    "SELECT TOP 1 Value FROM SingleDataTable WHERE TagId = @TagId AND TimeStamp > @StartDate AND TimeStamp <= @EndDate ORDER BY TimeStamp DESC",
                    connection);
                lastCommand.Parameters.AddWithValue("@TagId", tagId);
                lastCommand.Parameters.AddWithValue("@StartDate", startDate);
                lastCommand.Parameters.AddWithValue("@EndDate", endDate);

                var lastReading = 0.0;
                var lastResult = await lastCommand.ExecuteScalarAsync();
                if (lastResult != null && lastResult != DBNull.Value)
                {
                    lastReading = Convert.ToDouble(lastResult);
                }

                return lastReading - firstReading;
            }
        }

        public async Task<double> GetFirstConsumptionOfDay(int tagId, DateTime date)
        {
            using (var connection = new SqlConnection(_storageConnectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    "SELECT TOP 1 Value FROM SingleDataTable WHERE TagId = @TagId AND CAST(TimeStamp AS DATE) = CAST(@Date AS DATE) ORDER BY TimeStamp ASC",
                    connection);
                command.Parameters.AddWithValue("@TagId", tagId);
                command.Parameters.AddWithValue("@Date", date.Date);

                var result = await command.ExecuteScalarAsync();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDouble(result);
                }
                return 0.0;
            }
        }

        public async Task<List<int>> GetCoolingLoadTagsAsync()
        {
            var tagIds = new List<int>();

            try
            {
                using (var connection = new SqlConnection(_systemConnectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT TagId FROM TagConfig WHERE Equipment = 2", connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tagIdValue = reader["TagId"];
                            if (tagIdValue != null && tagIdValue != DBNull.Value)
                            {
                                if (int.TryParse(tagIdValue.ToString(), out int tagId))
                                {
                                    tagIds.Add(tagId);
                                }
                                else
                                {
                                    Console.WriteLine($"[WARN] Invalid TagId format: {tagIdValue}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARN] Could not get cooling load tags: {ex.Message}");
            }

            return tagIds;
        }

        // Placeholder implementations for other interface methods
        public async Task<IList<double>> GetAverageByWeekdayAsync(IList<int> tagIds, DateTime endDate, int numberOfDays)
        {
            return new List<double>();
        }

        public async Task<double> GetConsumptionDifference(int TagId, DateTime startDate, DateTime endDate)
        {
            return 0.0;
        }

        public async Task<TwoMonthViewChartDto> GetLastTwoMonthConsumptionDetails(List<int> tagIds, EnergyTypeConfig type)
        {
            return new TwoMonthViewChartDto();
        }

        public async Task<List<ChartData>> GetWeeklyConsumptionDetails(List<int> tagIds, DateTime selectedDate)
        {
            return new List<ChartData>();
        }

        public async Task<List<ChartData>> GetMonthlyConsumptionDetails(List<int> tagIds, DateTime startDate)
        {
            return new List<ChartData>();
        }

        public async Task<List<ChartData>> GetYearlyConsumptionDetails(List<int> tagIds, int month, int year)
        {
            return new List<ChartData>();
        }

        public async Task<List<ChartData>> GetSixMonthConsumptionDetails(List<int> tagIds, int month, int year)
        {
            return new List<ChartData>();
        }

        public Tuple<string, double, double> GetTwoMonthPercentageDetails(double lastMonthValue, double monthBeforeLastValue)
        {
            return new Tuple<string, double, double>("", 0, 0);
        }

        public async Task<List<int>> GetMeterTagIds(EnergyTypeConfig energyType)
        {
            return new List<int>();
        }

        public async Task<double> GetTotalConsumptionValue(List<int> tagIds, DateTime start, DateTime end)
        {
            return 0.0;
        }

        public async Task<List<int>> GetAveragePersonCountLastSixMonth(List<int> tagId)
        {
            return new List<int>();
        }

        public DateTime GetCurrentMonthEnd()
        {
            return DateTime.Now;
        }

        public DateTime GetCurrentYearEnd()
        {
            return DateTime.Now;
        }

        public async Task<List<DailyReadingDto>> GetConsumptionDifferenceFromStorageDb(List<int> tagIds, DateTime startDate, DateTime endDate)
        {
            return new List<DailyReadingDto>();
        }
    }
}