using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewBomberConfig", fileName = "BomberConfig")]
    public class BomberConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Bomber";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 9;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 50;
        
        [field: SerializeField, Min(0)] public float AttackProcessTime { get; private set; } = 0f;
        [field: SerializeField, Min(0)] public float BlowDamage { get; private set; } = 10;
        [field: SerializeField, Min(0)] public float BlowRadius { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0f;
    }
}