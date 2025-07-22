using DataPatchingService.Configurations;
using DataPatchingService.DTOs;
using DataPatchingService.Models;
using DataPatchingService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataPatchingService.Repositories
{
    public class ConfigDashboardRepo : IConfigDashboard
    {
        private readonly string _connectionString;

        public ConfigDashboardRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<int>> GetAllTagIds()
        {
            var tagIds = new List<int>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var command1 = new SqlCommand("SELECT TagId FROM TagConfig", connection);
                    using (var reader = await command1.ExecuteReaderAsync())
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
                catch (Exception ex)
                {
                    Console.WriteLine($"[WARN] Could not read TagConfig table: {ex.Message}");
                }

                try
                {
                    var command2 = new SqlCommand("SELECT TagId FROM SolarTagConfig", connection);
                    using (var reader = await command2.ExecuteReaderAsync())
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
                catch (Exception ex)
                {
                    Console.WriteLine($"[WARN] Could not read SolarTagConfig table: {ex.Message}");
                }
            }

            return tagIds;
        }

        // Required interface methods with placeholder implementations
        public async Task<List<TagConfig>> GetAllEquipmentList()
        {
            return new List<TagConfig>();
        }

        public async Task CreateLogForAllType(int levelId, string equipmentCode, EnergyTypeConfig configurationType, double updatedValue, int day, string userName)
        {
            // Not needed for data patch
        }

        public async Task<List<EquipmentConfigurationDtoInDetails>> GetAllEquipmentListInDetails(EnergyTypeConfig energyType, int levelId)
        {
            return new List<EquipmentConfigurationDtoInDetails>();
        }

        public async Task<bool> GetAllExistingConfigurationList(EnergyTypeConfig energyType, int levelId)
        {
            return false;
        }

        public async Task<EquipmentConfig> GetEquipmentId(int configId)
        {
            return new EquipmentConfig();
        }

        public async Task<EquipmentConfig> UpdateConfiguration(EquipmentConfigurationDto configDto, EquipmentConfig config, string userName)
        {
            return new EquipmentConfig();
        }

        public async Task UpdateAllConfigurations(ConfigurationApplyAllDto configDto, string userName)
        {
            // Not needed for data patch
        }

        public async Task<List<EquipmentConfig>> GetAllAutoModeConfigurations()
        {
            return new List<EquipmentConfig>();
        }

        public async Task CreateLog(int id, double updatedValue, int day, string userName)
        {
            // Not needed for data patch
        }

        public async Task<EquipmentConfig> UpdateConfiguration(EquipmentConfig configDto)
        {
            return new EquipmentConfig();
        }
    }
}