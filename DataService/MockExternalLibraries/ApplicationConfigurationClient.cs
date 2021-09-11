using System.Collections.Concurrent;

namespace DataService.MockExternalLibraries
{
    public interface IApplicationConfigurationClient
    {
        bool TryGetValue(string settingName, out string settingValue);
    }

    public class ApplicationConfigurationClient : IApplicationConfigurationClient
    {
        private readonly ConcurrentDictionary<string, string> settings = new ConcurrentDictionary<string, string>();

        public ApplicationConfigurationClient()
        {
            PopulateWithMockSettings();
        }

        private void PopulateWithMockSettings()
        {
            settings["ApisToLog"] = "/api";
        }

        public bool TryGetValue(string settingName, out string settingValue)
        {
            return settings.TryGetValue(settingName, out settingValue);
        }
    }
}
