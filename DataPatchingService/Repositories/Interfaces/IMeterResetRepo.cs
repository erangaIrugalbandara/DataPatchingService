// Repositories/Interfaces/IMeterResetRepo.cs
using DataPatchingService.Models;
using DataPatchingService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPatchingService.Repositories.Interfaces
{
    public interface IMeterResetRepo
    {
        Task SaveOrUpdateDailyConsumptionValueAsync(DailyMeterReading dailyMeter, bool isExist);
        Task<DailyMeterReading> GetDailyConsumptionValueAsync(int tagId, DateTime date);
        Task CalculateCurrentDayConsumptionValuesByTags(List<int> tagIds, IConsumptionCalculationRepo repo, DateTime date);
    }
}