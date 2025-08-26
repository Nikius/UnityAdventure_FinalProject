using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class EmptyState : State, IUpdatableState
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("EmptyState Enter");
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("EmptyState Enter");
        }

        public void Update(float deltaTime)
        {
        }
    }
}