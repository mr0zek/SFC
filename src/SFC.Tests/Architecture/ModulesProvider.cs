using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SFC.Tests.Architecture
{
  class ModulesProvider
  {
    public static string[] GetModuleNames()
    {
      return new string[] { "SFC.Accounts","SFC.Alerts","SFC.Notifications","SFC.Processes" };
    }

    public static IEnumerable<Assembly> GetModuleAssemblies()
    {
      return GetModuleNames().Select(f=> Assembly.LoadWithPartialName(f));
    }
  }
}
