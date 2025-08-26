using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Utilities.Conditions;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class LowestHealthInRadiusTargetSelector : ITargetSelector
    {
        private Entity _source;
        private Transform _sourceTransform;
        private float _radius;

        public LowestHealthInRadiusTargetSelector(Entity entity, float radius)
        {
            _source = entity;
            _radius = radius;
            _sourceTransform = entity.Transform;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
                target.HasComponent<TakeDamageRequest>() &&
                target != _source &&
                GetDistanceTo(target) <= _radius &&
                (!target.TryGetCanApplyDamage(out ICompositeCondition condition) || condition.Evaluate())
            ).ToList();

            if (selectedTargets.Any() == false)
                return null;

            Entity minHealthTarget = selectedTargets.First();
            float minHealth = GetHealth(minHealthTarget);

            foreach (Entity target in selectedTargets)
            {
                float currentHealth = GetHealth(target);

                if(currentHealth < minHealth)
                {
                    minHealth = currentHealth;
                    minHealthTarget = target;
                }
            }

            return minHealthTarget;
        }
        
        private float GetDistanceTo(Entity target) => (_sourceTransform.position - target.Transform.position).magnitude;

        private float GetHealth(Entity target) => target.CurrentHealth.Value;
    }
}