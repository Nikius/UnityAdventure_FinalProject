using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameModeConfig", fileName = "GameModeConfig")]
    public class GameModesConfig : ScriptableObject
    {
        [field: SerializeField] public MoneyConfig Reward { get; private set; }
        [field: SerializeField] public MoneyConfig Penalty { get; private set; }
        [field: SerializeField] public MoneyConfig ResetScorePrice { get; private set; }
        
        void OnValidate()
        {
            if (Reward is not { Value: >= 0 })
                throw new ApplicationException("Reward Value must be equals or greater than zero");
            
            if (Penalty is not { Value: >= 0 })
                throw new ApplicationException("Penalty Value must be equals or greater than zero");
            
            if (ResetScorePrice is not { Value: >= 0 })
                throw new ApplicationException("Reset Score Price must be equals or greater than zero");
        }
    }
}