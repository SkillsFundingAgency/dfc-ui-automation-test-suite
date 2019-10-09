using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public class ConfigSection : IConfigSection
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigSection(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public T GetConfigSection<T>()
        {
            return _configurationRoot.GetSection(typeof(T).Name).Get<T>();
        }
    }
}
