using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NetArchTest.Rules;
using Microsoft.EntityFrameworkCore.Internal;
using Autofac;
using System.Reflection;

namespace SFC.Tests.Architecture
{

  public class ModuleIsolationChecks
  {
    [Fact]
    public void Module_should_not_have_contract_and_implementation_namespaces()
    {
      foreach (Assembly assembly in ModulesProvider.GetModuleAssemblies())
      {
        var implementationTypes = Types.InAssembly(assembly).That().ResideInNamespaceMatching(".*[.]Implementation");
        Assert.True(implementationTypes.GetTypes().Any(), $"Missing implementation namespace in: {assembly.FullName}");

        var contractTypes = Types.InAssemblies(ModulesProvider.GetModuleAssemblies()).That().ResideInNamespaceMatching(".*[.]Contract$");
        Assert.True(contractTypes.GetTypes().Any(), $"Missing contract namespace in: {assembly.FullName}");
      }
    }

    [Fact]
    public void Module_every_type_except_contracts_should_not_be_public()
    {
      var types = Types.InAssemblies(ModulesProvider.GetModuleAssemblies())
        .That()
        .DoNotInherit(typeof(Autofac.Module))
        .And()
        .DoNotResideInNamespaceMatching(".*[.]Contract");
      Assert.NotEmpty(types.GetTypes());

      var result = types.Should()
        .NotBePublic()
        .GetResult();

      Assert.True(result.IsSuccessful, result.FailingTypeNames?.Join(",\n"));
    }
  }
}
