using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameModeConfig", fileName = "GameModeConfig")]
    public class GameModesConfig : ScriptableObject
    {
        [field: SerializeField] public int LengthOfStringForType { get; private set; }
        [field: SerializeField] public List<string> SymbolsSets { get; private set; }
    }
}