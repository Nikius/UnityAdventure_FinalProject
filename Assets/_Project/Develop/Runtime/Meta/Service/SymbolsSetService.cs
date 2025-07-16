using System.Collections.Generic;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;

namespace _Project.Develop.Runtime.Meta.Service
{
    public static class SymbolsSetService
    {
        public static List<string> LoadSymbolsSets(DIContainer container)
        {
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            GameModesConfig gameModesConfig = configsProviderService.GetConfig<GameModesConfig>();
            
            return gameModesConfig.SymbolsSets;
        }
    }
}