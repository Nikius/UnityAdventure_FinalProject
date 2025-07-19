using System;
using _Project.Develop.Runtime.Common.Controllers;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Score;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Controllers
{
    public class ShowPlayerDataController: Controller
    {
        public ShowPlayerDataController(DIContainer container) : base(container)
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ShowScore();
            }
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                ShowWallet();
            }
        }

        private void ShowScore()
        {
            ScoreService scoreService = Container.Resolve<ScoreService>();

            Debug.Log("Your Scores:");

            foreach (ScoreTypes scoreType in Enum.GetValues(typeof(ScoreTypes)))
                Debug.Log($"{scoreType}: {scoreService.GetScore(scoreType).Value}");
        }

        private void ShowWallet()
        {
            WalletService walletService = Container.Resolve<WalletService>();
            
            Debug.Log("Your Wallet:");

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
                Debug.Log($"{currencyType}: {walletService.GetCurrency(currencyType).Value}");
        }
    }
}