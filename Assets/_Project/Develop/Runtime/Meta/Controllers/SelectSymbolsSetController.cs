using System.Collections.Generic;
using _Project.Develop.Runtime.Common.Controllers;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Service;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Controllers
{
    public class SelectSymbolsSetController: Controller
    {
        private const int KeyCodeAlpha1 = (int)KeyCode.Alpha1;
        
        
        private List<string> _symbolsSets;

        public SelectSymbolsSetController(DIContainer container): base(container)
        {}

        public void Initialize()
        {
            _symbolsSets = SymbolsSetService.LoadSymbolsSets(Container);
        }

        public void ShowSelectRequest()
        {
            Debug.Log("Choose one of the following symbols set for game: ");
            
            for (int i = 0; i < _symbolsSets.Count; i++)
                Debug.Log($"{i+1}. {_symbolsSets[i]}");
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (Input.anyKeyDown)
                for (int i = KeyCodeAlpha1; i < KeyCodeAlpha1 + _symbolsSets.Count; i++)
                    if (Input.GetKeyDown((KeyCode)i))
                        StartGameService.StartGame(Container, i - KeyCodeAlpha1);
        }
    }
}