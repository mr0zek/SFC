using System.Collections.Generic;
using Xunit;
using NetArchTest.Rules;
using Microsoft.EntityFrameworkCore.Internal;
using SFC.Infrastructure;

namespace SFC.Tests.Architecture
{
  public class ContractChecks
  {
    [Fact]
    public void Module_contract_should_be_public_classes_or_injection_interface()
    {
      var types = Types.InAssemblies(ModulesProvider.GetModuleAssemblies())
        .That()
        .DoNotImplementInterface(typeof(IInjection))
        .And()
        .ResideInNamespaceMatching(".*[.]Contract$");
      Assert.NotEmpty(types.GetTypes());

      var result = types
        .Should()
        .BeClasses().And().BePublic()
        .GetResult();

      Assert.True(result.IsSuccessful, result.FailingTypeNames?.Join(",\n"));

      var types2 = Types.InAssemblies(ModulesProvider.GetModuleAssemblies())
        .That()
        .ImplementInterface(typeof(IInjection))
        .And()
        .ResideInNamespaceMatching(".*[.]Contract$");
      Assert.NotEmpty(types2.GetTypes());

      var result2 = types2
        .Should()
        .BeInterfaces().And().BePublic()
        .GetResult();

      Assert.True(result2.IsSuccessful, result2.FailingTypeNames?.Join(",\n"));
    }

    [Fact]
    public void Contract_should_be_separated_to_commands_events_query_injection()
    {
      var types = Types.InAssemblies(ModulesProvider.GetModuleAssemblies())
        .That()
        .ResideInNamespaceMatching(".*[.]Contract$");
      Assert.NotEmpty(types.GetTypes());

      var result = types
        .Should()
        .ImplementInterface(typeof(IEvent))
        .Or()
        .ImplementInterface(typeof(ICommand))
        .Or()
        .ImplementInterface(typeof(IQuery))
        .Or()
        .ImplementInterface(typeof(IInjection))
        .And()
        .BePublic()
        .GetResult();

      Assert.True(result.IsSuccessful, result.FailingTypeNames?.Join(",\n"));
    }

    [Fact]
    public void Contract_should_command_event_query_naming_convention()
    {
      var types = Types.InAssemblies(ModulesProvider.GetModuleAssemblies())
        .That()
        .ResideInNamespaceMatching(".*[.]Contract$");
      Assert.NotEmpty(types.GetTypes());

      var result = types
        .Should()
        .HaveNameEndingWith("Event")
        .Or()
        .HaveNameEndingWith("Command")
        .Or()
        .HaveNameEndingWith("Query")
        .Or()
        .ImplementInterface(typeof(IInjection))
        .And()
        .BePublic()
        .GetResult();

      Assert.True(result.IsSuccessful, result.FailingTypeNames?.Join(",\n"));
    }
  }
}
