using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _currentEntity;
        private Entity _rigidbodyEntity;
        private Entity _characterControllerEntity;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _rigidbodyEntity = _entitiesFactory.CreateRigidbodyEntity(new Vector3(1, 0, 0));
            _characterControllerEntity = _entitiesFactory.CreateCharacterControllerEntity(new Vector3(-1, 0, 0));
            _currentEntity = _rigidbodyEntity;

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false) 
                return;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                _currentEntity = _rigidbodyEntity;
                Debug.Log("Activated RigidBody Entity");
            }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                _currentEntity = _characterControllerEntity;
                Debug.Log("Activated CharacterController Entity");
            }
            
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            _currentEntity.MoveDirection.Value = input;
        }
    }
}
