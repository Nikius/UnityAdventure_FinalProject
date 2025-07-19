using _Project.Develop.Runtime.Common.Controllers;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Score;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.DataManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Controllers
{
    public class ResetScoreController: Controller
    {
        private WalletService _walletService;
        private ScoreService _scoreService;
        private GameModesConfig _gameModesConfig;
        
        public ResetScoreController(DIContainer container) : base(container)
        {
        }

        public void Initialize()
        {
            _walletService = Container.Resolve<WalletService>();
            _scoreService = Container.Resolve<ScoreService>();
            ConfigsProviderService configsProviderService = Container.Resolve<ConfigsProviderService>();
            _gameModesConfig = configsProviderService.GetConfig<GameModesConfig>();
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ResetScore();
                RunAutosave();
            }
        }

        private void ResetScore()
        {
            if (_walletService.Enough(_gameModesConfig.ResetScorePrice.Type, _gameModesConfig.ResetScorePrice.Value))
            {
                _walletService.Spend(_gameModesConfig.ResetScorePrice.Type, _gameModesConfig.ResetScorePrice.Value);
                _scoreService.Reset();
                Debug.Log("Your score was reset");
            }
            else
            {
                Debug.Log($"You are have not enough {_gameModesConfig.ResetScorePrice.Type} for reset score. Need {_gameModesConfig.ResetScorePrice.Value}.");
            }
        }
        
        private void RunAutosave()
        {
            AutosaveService autosaveService = Container.Resolve<AutosaveService>();
            autosaveService.Run();
        }
    }
}