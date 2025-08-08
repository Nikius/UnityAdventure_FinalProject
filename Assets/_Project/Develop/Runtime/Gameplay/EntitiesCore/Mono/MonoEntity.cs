using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntity: MonoBehaviour
    {
        private CollidersRegistryService _collidersRegistryService;
        
        public Entity LinkedEntity { get; private set; }

        public void Initialize(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void Link(Entity entity)
        {
            LinkedEntity = entity;
            
            MonoEntityRegistrator[] registrators = GetComponentsInChildren<MonoEntityRegistrator>();
            
            if (registrators != null)
                foreach (MonoEntityRegistrator registrator in registrators)
                    registrator.Register(entity);

            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _collidersRegistryService.Register(collider, entity);
        }

        public void Cleanup(Entity entity)
        {
            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _collidersRegistryService.Unregister(collider);
            
            LinkedEntity = null;
        }
    }
}