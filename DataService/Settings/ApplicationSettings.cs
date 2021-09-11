using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Misc;
using DataService.MockExternalLibraries;
using Microsoft.Extensions.Configuration;

namespace DataService.Settings
{
    public interface IApplicationSettings
    {
        string[] EndpointsToLog { get; }
    }

    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IApplicationConfigurationClient applicationConfigurationClient;

        public ApplicationSettings(
            IApplicationConfigurationClient applicationConfigurationClient)
        {
            this.applicationConfigurationClient = applicationConfigurationClient;
        }

        public string[] EndpointsToLog
            => applicationConfigurationClient.TryGetValue("ApisToLog", out var settingValue)
                ? Utils.CommaSeparatedStringToArray(settingValue).Select(x => x.Trim()).ToArray()
                : new[] { "/api" };
    }
}
