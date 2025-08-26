using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.Features.AI.States;
using _Project.Develop.Runtime.Gameplay.Features.InputService;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.Timer;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;
        private readonly IInputService _inputService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputService = _container.Resolve<IInputService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }
        
        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;

            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            ICompositeCondition fromMovementToAttackTriggerStateCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() => _inputService.IsAttackButtonDown()))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositeCondition fromAttackTriggerToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => canAttack.Evaluate() == false))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(attackTriggerState);

            behaviour.AddTransition(movementState, attackTriggerState, fromMovementToAttackTriggerStateCondition);
            behaviour.AddTransition(attackTriggerState, movementState, fromAttackTriggerToMovementStateCondition);

            StateMachineBrain brain = new StateMachineBrain(behaviour);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }


        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomMovementStateMachine(entity);
            StateMachineBrain brain = new StateMachineBrain(stateMachine);
            
            _brainsContext.SetFor(entity, brain);
            
            return brain;
        }
        
        public StateMachineBrain CreateTeleporterBrain(Entity entity, ITargetSelector targetSelector)
        {
            EmptyState emptyState = new EmptyState();
            
            TeleportationState teleportationState = new TeleportationState(
                entity,
                targetSelector,
                _entitiesLifeContext
            );

            ICompositeCondition fromEmptyToTeleportationStateCondition = entity.CanStartTeleport;
            fromEmptyToTeleportationStateCondition.Add(
                new FuncCondition(() => entity.CurrentEnergy.Value >= entity.MaxEnergy.Value * 0.4)
            );
            
            FuncCondition fromTeleportationToEmptyStateCondition = new FuncCondition(() => entity.InTeleportProcess.Value = true);

            AIStateMachine stateMachine = new AIStateMachine();
            
            stateMachine.AddState(emptyState);
            stateMachine.AddState(teleportationState);
            
            stateMachine.AddTransition(emptyState, teleportationState, fromEmptyToTeleportationStateCondition);
            stateMachine.AddTransition(teleportationState, emptyState, fromTeleportationToEmptyStateCondition);
            
            StateMachineBrain brain = new StateMachineBrain(stateMachine);
            
            _brainsContext.SetFor(entity, brain);
            
            return brain;
        }
        
        private AIStateMachine CreateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);

            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));
            
            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            FuncCondition movementTimerEndedCondition = new FuncCondition(() => movementTimer.IsOver);
            FuncCondition idleTimerEndedCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(randomMovementState);
            stateMachine.AddState(emptyState);

            stateMachine.AddTransition(randomMovementState, emptyState, movementTimerEndedCondition);
            stateMachine.AddTransition(emptyState, randomMovementState, idleTimerEndedCondition);

            return stateMachine;
        }
    }
}