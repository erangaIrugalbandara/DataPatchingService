using DataPatchingService.Models;
using DataPatchingService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataPatchingService.Repositories
{
    public class MeterResetRepo : IMeterResetRepo
    {
        private readonly string _connectionString;

        public MeterResetRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DailyMeterReading> GetDailyConsumptionValueAsync(int tagId, DateTime date)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    "SELECT Id, TagId, Value, TimeStamp FROM DailyMeterReadings WHERE TagId = @TagId AND CAST(TimeStamp AS DATE) = CAST(@Date AS DATE)",
                    connection);
                command.Parameters.AddWithValue("@TagId", tagId);
                command.Parameters.AddWithValue("@Date", date.Date);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var dailyMeterReading = new DailyMeterReading();

                        // Safe conversion for Id
                        var idValue = reader["Id"];
                        if (idValue != null && idValue != DBNull.Value)
                        {
                            if (int.TryParse(idValue.ToString(), out int id))
                            {
                                dailyMeterReading.Id = id;
                            }
                            else
                            {
                                Console.WriteLine($"[WARN] Invalid Id format: {idValue}");
                                dailyMeterReading.Id = 0; // Default value
                            }
                        }
                        // Safe conversion for TagId
                        var tagIdValue = reader["TagId"];
                        if (tagIdValue != null && tagIdValue != DBNull.Value)
                        {
                            if (int.TryParse(tagIdValue.ToString(), out int parsedTagId))
                            {
                                dailyMeterReading.TagId = parsedTagId;
                            }
                            else
                            {
                                Console.WriteLine($"[WARN] Invalid TagId format: {tagIdValue}");
                                dailyMeterReading.TagId = 0; // Default value
                            }
                        }

                        // Safe conversion for Value
                        var valueValue = reader["Value"];
                        if (valueValue != null && valueValue != DBNull.Value)
                        {
                            if (double.TryParse(valueValue.ToString(), out double value))
                            {
                                dailyMeterReading.Value = value;
                            }
                            else
                            {
                                Console.WriteLine($"[WARN] Invalid Value format: {valueValue}");
                                dailyMeterReading.Value = 0.0; // Default value
                            }
                        }

                        // Safe conversion for TimeStamp
                        var timeStampValue = reader["TimeStamp"];
                        if (timeStampValue != null && timeStampValue != DBNull.Value)
                        {
                            if (DateTime.TryParse(timeStampValue.ToString(), out DateTime timeStamp))
                            {
                                dailyMeterReading.TimeStamp = timeStamp;
                            }
                            else
                            {
                                Console.WriteLine($"[WARN] Invalid TimeStamp format: {timeStampValue}");
                                dailyMeterReading.TimeStamp = DateTime.MinValue; // Default value
                            }
                        }

                        return dailyMeterReading;
                    }
            
                }
            }
            return null;
        }

        public async Task SaveOrUpdateDailyConsumptionValueAsync(DailyMeterReading dailyMeter, bool isExist)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command;

                if (isExist)
                {
                    command = new SqlCommand(
                        "UPDATE DailyMeterReadings SET Value = @Value WHERE Id = @Id",
                        connection);
                    command.Parameters.AddWithValue("@Id", dailyMeter.Id);
                    command.Parameters.AddWithValue("@Value", dailyMeter.Value);
                }
                else
                {
                    command = new SqlCommand(
                        "INSERT INTO DailyMeterReadings (TagId, Value, TimeStamp) VALUES (@TagId, @Value, @TimeStamp)",
                        connection);
                    command.Parameters.AddWithValue("@TagId", dailyMeter.TagId);
                    command.Parameters.AddWithValue("@Value", dailyMeter.Value);
                    command.Parameters.AddWithValue("@TimeStamp", dailyMeter.TimeStamp);
                }

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task CalculateCurrentDayConsumptionValuesByTags(List<int> tagIds, IConsumptionCalculationRepo repo, DateTime date)
        {
            // Not needed for data patch
        }
    }
}