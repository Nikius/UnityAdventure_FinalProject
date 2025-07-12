﻿using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayInputArgs: IInputSceneArgs
    {
        public GameplayInputArgs(int symbolsSetIndex)
        {
            SymbolsSetIndex = symbolsSetIndex;
        }

        public int SymbolsSetIndex { get; }
    }
}