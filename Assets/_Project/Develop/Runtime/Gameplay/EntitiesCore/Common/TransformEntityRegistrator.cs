using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore.Common
{
    public class TransformEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddTransform(transform);
        }
    }
}