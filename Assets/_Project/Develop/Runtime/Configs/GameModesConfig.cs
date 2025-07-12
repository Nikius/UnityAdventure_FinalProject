using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameModeConfig", fileName = "GameModeConfig")]
    public class GameModesConfig : ScriptableObject
    {
        [field: SerializeField] public int LengthOfStringForType { get; private set; }
        [field: SerializeField] public List<string> SymbolsSets { get; private set; }
        
        void OnValidate()
        {
            if (SymbolsSets.Count == 0)
                throw new ApplicationException("Symbols set count should be more than zero");
            if (SymbolsSets.Count > 9)
                throw new ApplicationException("Symbols set count should be less than nine");
            if (LengthOfStringForType <= 0)
                throw new ApplicationException("Length Of String For Type should be greater than zero");
        }
    }
}