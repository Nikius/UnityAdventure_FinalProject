using System.Collections.Generic;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Service;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Controllers
{
    public class SelectSymbolsSetController
    {
        private const int KeyCodeAlpha1 = (int)KeyCode.Alpha1;
        
        private readonly DIContainer _container;
        
        private List<string> _symbolsSets;

        public SelectSymbolsSetController(DIContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _symbolsSets = SymbolsSetService.LoadSymbolsSets(_container);
        }

        public void ShowSelectRequest()
        {
            Debug.Log("Choose one of the following symbols set for game: ");
            
            for (int i = 0; i < _symbolsSets.Count; i++)
                Debug.Log($"{i+1}. {_symbolsSets[i]}");
        }

        public void Update()
        {
            if (Input.anyKeyDown)
                for (int i = KeyCodeAlpha1; i < KeyCodeAlpha1 + _symbolsSets.Count; i++)
                    if (Input.GetKeyDown((KeyCode)i))
                        StartGameService.StartGame(_container, i - KeyCodeAlpha1);
        }
    }
}