// Updated Program.cs - Using the new class names
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DataPatchingService.Services;
using DataPatchingService.Repositories;

namespace DataPatchingService
{
    class Program
    {
        private static string _systemConnectionString;
        private static string _storageConnectionString;
        private static bool _isDataPatch;
        private static DateTime _dataPatchStartTime;
        private static DateTime _dataPatchEndTime;

        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Data Patching Service Starting...");

                LoadConfiguration();
                Console.WriteLine("[INFO] Data Patch Console Application Started");

                if (!_isDataPatch)
                {
                    Console.WriteLine("[WARN] Data patch is disabled in configuration.");
                    Console.WriteLine("Data patch is disabled in configuration. Press any key to exit...");
                    Console.ReadKey();
                    return;
                }

                if (_dataPatchStartTime > _dataPatchEndTime)
                {
                    Console.WriteLine("[ERROR] Data patch start time cannot be greater than end time.");
                    Console.WriteLine("Data patch start time cannot be greater than end time. Press any key to exit...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"Starting data patch from {_dataPatchStartTime:yyyy-MM-dd} to {_dataPatchEndTime:yyyy-MM-dd}");

                // Use the NEW class names to avoid conflicts
                var consumptionRepo = new ConsumptionCalculationRepo(_storageConnectionString, _systemConnectionString);
                var configRepo = new ConfigDashboardRepo(_systemConnectionString);
                var meterRepo = new MeterResetRepo(_systemConnectionString);

                Console.WriteLine("[INFO] Testing database connections...");
                if (await configRepo.TestConnectionAsync())
                {
                    Console.WriteLine("[INFO] System database connection successful");
                }
                else
                {
                    Console.WriteLine("[ERROR] System database connection failed");
                    Console.ReadKey();
                    return;
                }

                var dataPatchService = new DataPatchService(consumptionRepo, configRepo, meterRepo);
                await dataPatchService.ExecuteDataPatchAsync(_dataPatchStartTime, _dataPatchEndTime);

                Console.WriteLine("Data patch completed successfully. Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void LoadConfiguration()
        {
            try
            {
                var jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                if (!File.Exists(jsonFile))
                {
                    throw new FileNotFoundException($"Configuration file not found: {jsonFile}");
                }

                var jsonContent = File.ReadAllText(jsonFile);
                var config = JObject.Parse(jsonContent);

                _systemConnectionString = config["ConnectionStrings"]["SystemDBConnection"]?.ToString();
                _storageConnectionString = config["ConnectionStrings"]["StorageDBConnection"]?.ToString();
                _isDataPatch = bool.Parse(config["DataPatchSettings"]["IsDataPatch"]?.ToString() ?? "false");
                _dataPatchStartTime = DateTime.Parse(config["DataPatchSettings"]["DataPatchStartDate"]?.ToString() ?? DateTime.Now.ToString());
                _dataPatchEndTime = DateTime.Parse(config["DataPatchSettings"]["DataPatchEndDate"]?.ToString() ?? DateTime.Now.ToString());

                Console.WriteLine("Configuration loaded successfully:");
                Console.WriteLine($"- System DB: {_systemConnectionString?.Substring(0, Math.Min(50, _systemConnectionString.Length))}...");
                Console.WriteLine($"- Storage DB: {_storageConnectionString?.Substring(0, Math.Min(50, _storageConnectionString.Length))}...");
                Console.WriteLine($"- Data Patch Enabled: {_isDataPatch}");
                Console.WriteLine($"- Start Date: {_dataPatchStartTime:yyyy-MM-dd}");
                Console.WriteLine($"- End Date: {_dataPatchEndTime:yyyy-MM-dd}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load configuration: {ex.Message}", ex);
            }
        }
    }
}