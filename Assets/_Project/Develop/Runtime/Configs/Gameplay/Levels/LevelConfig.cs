using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelConfig", fileName = "LevelConfig")]
    public class LevelConfig: ScriptableObject
    {
        [field: SerializeField] public string SymbolsSet { get; private set; }
        [field: SerializeField, Min(1)] public int LengthOfStringForType { get; private set; }

        void OnValidate()
        {
            if (SymbolsSet.Length <= 1)
                throw new ApplicationException("Symbols set cannot be empty");
        }
    }
}