﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFA.DFC.UI.Framework.TestSupport
{
    internal static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        private readonly static IConfigurationRoot _hostingConfig;

        static Configurator()
        {
            //_hostingConfig = InitializeHostingConfig();
            _config = InitializeConfig();
        }

        internal static IConfigurationRoot GetConfig()
        {
            return _config;
        }

        internal static string GetAgentMachineName(this IConfigurationRoot configurationRoot)
        {
            return configurationRoot.GetSection("AGENT_MACHINENAME")?.Value;
        }

        private static IConfigurationRoot InitializeConfig()
        {
            //var EnvironmentName = _hostingConfig.GetSection("Release_EnvironmentName").Value;
            //var ProjectName = _hostingConfig.GetSection("ProjectName").Value;

            return ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddEnvironmentVariables()
            //.AddUserSecrets("BrowserStackSecrets")
            //.AddUserSecrets($"{ProjectName}_{EnvironmentName}_Secrets")
            //.AddUserSecrets("MongoDbSecrets")
            .Build();
        }

        private static IConfigurationRoot InitializeHostingConfig()
        {
            return ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .Build();
        }

        private static IConfigurationBuilder ConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory());
        }
    }
}
