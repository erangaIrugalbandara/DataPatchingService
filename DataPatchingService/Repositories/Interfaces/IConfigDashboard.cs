// Repositories/Interfaces/IConfigDashboard.cs
using DataPatchingService.Configurations;
using DataPatchingService.DTOs;
using DataPatchingService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPatchingService.Repositories.Interfaces
{
    public interface IConfigDashboard
    {
        Task<List<TagConfig>> GetAllEquipmentList();
        Task<List<int>> GetAllTagIds();
        Task CreateLogForAllType(int levelId, string equipmentCode, EnergyTypeConfig configurationType, double updatedValue, int day, string userName);
        Task<List<EquipmentConfigurationDtoInDetails>> GetAllEquipmentListInDetails(EnergyTypeConfig energyType, int levelId);
        Task<bool> GetAllExistingConfigurationList(EnergyTypeConfig energyType, int levelId);
        Task<EquipmentConfig> GetEquipmentId(int configId);
        Task<EquipmentConfig> UpdateConfiguration(EquipmentConfigurationDto configDto, EquipmentConfig config, string userName);
        Task UpdateAllConfigurations(ConfigurationApplyAllDto configDto, string userName);
        Task<List<EquipmentConfig>> GetAllAutoModeConfigurations();
        Task CreateLog(int id, double updatedValue, int day, string userName);
        Task<EquipmentConfig> UpdateConfiguration(EquipmentConfig configDto);
    }
}