using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public interface IConfigSection
    {
        T GetConfigSection<T>();
    }
}
