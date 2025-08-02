using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Meta.Features.Score;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Service
{
    public class ResetScoresService
    {
        private readonly WalletService _walletService;
        private readonly ScoreService _scoreService;
        private readonly GameModesConfig _gameModesConfig;
        
        public ResetScoresService(WalletService walletService, ScoreService scoreService, GameModesConfig gameModesConfig)
        {
            _walletService = walletService;
            _scoreService = scoreService;
            _gameModesConfig = gameModesConfig;
        }
        
        public void ResetScore()
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
    }
}