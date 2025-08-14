using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Sensors
{
    public class RadialContactsDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _mask;

        private ReactiveVariable<float> _radius;
        private CapsuleCollider _body;
        
        private ReactiveEvent _startAttackEvent;
        private IDisposable _startAttackDisposable;
        
        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _radius = entity.BlowRadius;
            _body = entity.BodyCollider;

            _startAttackEvent = entity.StartAttackEvent;
            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttackEvent);
        }

        private void OnStartAttackEvent()
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                _body.transform.position,
                _radius.Value,
                _contacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore
            );
            RemoveSelfFromContacts();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                    _contacts.Items[i] = _contacts.Items[i + 1];

                _contacts.Count--;
            }
        }

        public void OnDispose()
        {
            _startAttackDisposable.Dispose();
        }
    }
}