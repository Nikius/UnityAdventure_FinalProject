using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Common;
using _Project.Develop.Runtime.Gameplay.Features.AI.RandomTarget;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Gameplay.Features.Attack;
using _Project.Develop.Runtime.Gameplay.Features.Attack.Blow;
using _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage;
using _Project.Develop.Runtime.Gameplay.Features.Energy;
using _Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Gameplay.Features.Sensors;
using _Project.Develop.Runtime.Gameplay.Features.Teleport;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team TeamC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() {Value = value}); 
		}

		public TeleportRadius TeleportRadiusC => GetComponent<TeleportRadius>();

		public ReactiveVariable<Single> TeleportRadius => TeleportRadiusC.Value;

		public Entity AddTeleportRadius()
		{
			return AddComponent(new TeleportRadius() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddTeleportRadius(ReactiveVariable<Single> value)
		{
			return AddComponent(new TeleportRadius() {Value = value}); 
		}

		public TeleportTarget TeleportTargetC => GetComponent<TeleportTarget>();

		public ReactiveVariable<Vector3> TeleportTarget => TeleportTargetC.Value;

		public Entity AddTeleportTarget()
		{
			return AddComponent(new TeleportTarget() { Value = new ReactiveVariable<Vector3>() }); 
		}

		public Entity AddTeleportTarget(ReactiveVariable<Vector3> value)
		{
			return AddComponent(new TeleportTarget() {Value = value}); 
		}

		public TeleportEnergyCost TeleportEnergyCostC => GetComponent<TeleportEnergyCost>();

		public ReactiveVariable<Single> TeleportEnergyCost => TeleportEnergyCostC.Value;

		public Entity AddTeleportEnergyCost()
		{
			return AddComponent(new TeleportEnergyCost() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddTeleportEnergyCost(ReactiveVariable<Single> value)
		{
			return AddComponent(new TeleportEnergyCost() {Value = value}); 
		}

		public CanStartTeleport CanStartTeleportC => GetComponent<CanStartTeleport>();

		public ICompositeCondition CanStartTeleport => CanStartTeleportC.Value;

		public Entity AddCanStartTeleport(ICompositeCondition value)
		{
			return AddComponent(new CanStartTeleport() {Value = value}); 
		}

		public StartTeleportRequest StartTeleportRequestC => GetComponent<StartTeleportRequest>();

		public ReactiveEvent StartTeleportRequest => StartTeleportRequestC.Value;

		public Entity AddStartTeleportRequest()
		{
			return AddComponent(new StartTeleportRequest() { Value = new ReactiveEvent() }); 
		}

		public Entity AddStartTeleportRequest(ReactiveEvent value)
		{
			return AddComponent(new StartTeleportRequest() {Value = value}); 
		}

		public StartTeleportEvent StartTeleportEventC => GetComponent<StartTeleportEvent>();

		public ReactiveEvent StartTeleportEvent => StartTeleportEventC.Value;

		public Entity AddStartTeleportEvent()
		{
			return AddComponent(new StartTeleportEvent() { Value = new ReactiveEvent() }); 
		}

		public Entity AddStartTeleportEvent(ReactiveEvent value)
		{
			return AddComponent(new StartTeleportEvent() {Value = value}); 
		}

		public EndTeleportEvent EndTeleportEventC => GetComponent<EndTeleportEvent>();

		public ReactiveEvent EndTeleportEvent => EndTeleportEventC.Value;

		public Entity AddEndTeleportEvent()
		{
			return AddComponent(new EndTeleportEvent() { Value = new ReactiveEvent() }); 
		}

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public Entity AddEndTeleportEvent(ReactiveEvent value)
		{
			return AddComponent(new EndTeleportEvent() {Value = value}); 
		}

		public TeleportProcessInitialTime TeleportProcessInitialTimeC => GetComponent<TeleportProcessInitialTime>();

		public ReactiveVariable<Single> TeleportProcessInitialTime => TeleportProcessInitialTimeC.Value;

		public Entity AddTeleportProcessInitialTime()
		{
			return AddComponent(new TeleportProcessInitialTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Entity AddTeleportProcessInitialTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new TeleportProcessInitialTime() {Value = value}); 
		}

		public TeleportProcessCurrentTime TeleportProcessCurrentTimeC => GetComponent<TeleportProcessCurrentTime>();

		public ReactiveVariable<Single> TeleportProcessCurrentTime => TeleportProcessCurrentTimeC.Value;

		public Entity AddTeleportProcessCurrentTime()
		{
			return AddComponent(new TeleportProcessCurrentTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetContactCollidersBuffer(out _Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Entity AddTeleportProcessCurrentTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new TeleportProcessCurrentTime() {Value = value}); 
		}

		public InTeleportProcess InTeleportProcessC => GetComponent<InTeleportProcess>();

		public ReactiveVariable<Boolean> InTeleportProcess => InTeleportProcessC.Value;

		public Entity AddInTeleportProcess()
		{
			return AddComponent(new InTeleportProcess() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public bool TryGetContactEntitiesBuffer(out _Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Buffer<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Entity AddInTeleportProcess(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new InTeleportProcess() {Value = value}); 
		}

		public TeleportDelayTime TeleportDelayTimeC => GetComponent<TeleportDelayTime>();

		public ReactiveVariable<Single> TeleportDelayTime => TeleportDelayTimeC.Value;

		public Entity AddTeleportDelayTime()
		{
			return AddComponent(new TeleportDelayTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Entity AddTeleportDelayTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new TeleportDelayTime() {Value = value}); 
		}

		public TeleportDelayEndEvent TeleportDelayEndEventC => GetComponent<TeleportDelayEndEvent>();

		public ReactiveEvent TeleportDelayEndEvent => TeleportDelayEndEventC.Value;

		public Entity AddTeleportDelayEndEvent()
		{
			return AddComponent(new TeleportDelayEndEvent() { Value = new ReactiveEvent() }); 
		}

		public bool TryGetIsTouchDeathMask(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Entity AddTeleportDelayEndEvent(ReactiveEvent value)
		{
			return AddComponent(new TeleportDelayEndEvent() {Value = value}); 
		}

		public BodyCollider BodyColliderC => GetComponent<BodyCollider>();

		public CapsuleCollider BodyCollider => BodyColliderC.Value;

		public Entity AddBodyCollider(CapsuleCollider value)
		{
			return AddComponent(new BodyCollider() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam() {Value = value}); 
		}

		public ContactsDetectingMask ContactsDetectingMaskC => GetComponent<ContactsDetectingMask>();

		public LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetMoveDirection(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Entity AddContactsDetectingMask(LayerMask value)
		{
			return AddComponent(new ContactsDetectingMask() {Value = value}); 
		}

		public ContactCollidersBuffer ContactCollidersBufferC => GetComponent<ContactCollidersBuffer>();

		public Buffer<Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public Entity AddContactCollidersBuffer(Buffer<Collider> value)
		{
			return AddComponent(new ContactCollidersBuffer() {Value = value}); 
		}

		public ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<ContactEntitiesBuffer>();

		public Buffer<Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetMoveSpeed(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddContactEntitiesBuffer(Buffer<Entity> value)
		{
			return AddComponent(new ContactEntitiesBuffer() {Value = value}); 
		}

		public DeathMask DeathMaskC => GetComponent<DeathMask>();

		public LayerMask DeathMask => DeathMaskC.Value;

		public Entity AddDeathMask(LayerMask value)
		{
			return AddComponent(new DeathMask() {Value = value}); 
		}

		public IsTouchDeathMask IsTouchDeathMaskC => GetComponent<IsTouchDeathMask>();

		public ReactiveVariable<Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsMoving(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Entity AddIsTouchDeathMask()
		{
			return AddComponent(new IsTouchDeathMask() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddIsTouchDeathMask(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new IsTouchDeathMask() {Value = value}); 
		}

		public MoveDirection MoveDirectionC => GetComponent<MoveDirection>();

		public ReactiveVariable<Vector3> MoveDirection => MoveDirectionC.Value;

		public Entity AddMoveDirection()
		{
			return AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>() }); 
		}

		public bool TryGetCanMove(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddMoveDirection(ReactiveVariable<Vector3> value)
		{
			return AddComponent(new MoveDirection() {Value = value}); 
		}

		public MoveSpeed MoveSpeedC => GetComponent<MoveSpeed>();

		public ReactiveVariable<Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetRotationDirection(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Entity AddMoveSpeed()
		{
			return AddComponent(new MoveSpeed() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddMoveSpeed(ReactiveVariable<Single> value)
		{
			return AddComponent(new MoveSpeed() {Value = value}); 
		}

		public IsMoving IsMovingC => GetComponent<IsMoving>();

		public ReactiveVariable<Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetRotationSpeed(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddIsMoving()
		{
			return AddComponent(new IsMoving() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddIsMoving(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new IsMoving() {Value = value}); 
		}

		public CanMove CanMoveC => GetComponent<CanMove>();

		public ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanRotate(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddCanMove(ICompositeCondition value)
		{
			return AddComponent(new CanMove() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero IsMainHeroC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero>();

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero() ); 
		}

		public RotationDirection RotationDirectionC => GetComponent<RotationDirection>();

		public ReactiveVariable<Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetCurrentHealth(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddRotationDirection()
		{
			return AddComponent(new RotationDirection() { Value = new ReactiveVariable<Vector3>() }); 
		}

		public Entity AddRotationDirection(ReactiveVariable<Vector3> value)
		{
			return AddComponent(new RotationDirection() {Value = value}); 
		}

		public RotationSpeed RotationSpeedC => GetComponent<RotationSpeed>();

		public ReactiveVariable<Single> RotationSpeed => RotationSpeedC.Value;

		public Entity AddRotationSpeed()
		{
			return AddComponent(new RotationSpeed() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetMaxHealth(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddRotationSpeed(ReactiveVariable<Single> value)
		{
			return AddComponent(new RotationSpeed() {Value = value}); 
		}

		public CanRotate CanRotateC => GetComponent<CanRotate>();

		public ICompositeCondition CanRotate => CanRotateC.Value;

		public Entity AddCanRotate(ICompositeCondition value)
		{
			return AddComponent(new CanRotate() {Value = value}); 
		}

		public CurrentHealth CurrentHealthC => GetComponent<CurrentHealth>();

		public ReactiveVariable<Single> CurrentHealth => CurrentHealthC.Value;

		public Entity AddCurrentHealth()
		{
			return AddComponent(new CurrentHealth() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetMustDie(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddCurrentHealth(ReactiveVariable<Single> value)
		{
			return AddComponent(new CurrentHealth() {Value = value}); 
		}

		public MaxHealth MaxHealthC => GetComponent<MaxHealth>();

		public ReactiveVariable<Single> MaxHealth => MaxHealthC.Value;

		public Entity AddMaxHealth()
		{
			return AddComponent(new MaxHealth() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetMustSelfRelease(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddMaxHealth(ReactiveVariable<Single> value)
		{
			return AddComponent(new MaxHealth() {Value = value}); 
		}

		public MustDie MustDieC => GetComponent<MustDie>();

		public ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetIsDead(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Entity AddMustDie(ICompositeCondition value)
		{
			return AddComponent(new MustDie() {Value = value}); 
		}

		public MustSelfRelease MustSelfReleaseC => GetComponent<MustSelfRelease>();

		public ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public Entity AddMustSelfRelease(ICompositeCondition value)
		{
			return AddComponent(new MustSelfRelease() {Value = value}); 
		}

		public IsDead IsDeadC => GetComponent<IsDead>();

		public ReactiveVariable<Boolean> IsDead => IsDeadC.Value;

		public bool TryGetDeathProcessInitialTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddIsDead()
		{
			return AddComponent(new IsDead() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddIsDead(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new IsDead() {Value = value}); 
		}

		public DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<DeathProcessInitialTime>();

		public ReactiveVariable<Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new DeathProcessInitialTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddDeathProcessInitialTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new DeathProcessInitialTime() {Value = value}); 
		}

		public DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<DeathProcessCurrentTime>();

		public ReactiveVariable<Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetInDeathProcess(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new DeathProcessCurrentTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddDeathProcessCurrentTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new DeathProcessCurrentTime() {Value = value}); 
		}

		public InDeathProcess InDeathProcessC => GetComponent<InDeathProcess>();

		public ReactiveVariable<Boolean> InDeathProcess => InDeathProcessC.Value;

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public Entity AddInDeathProcess()
		{
			return AddComponent(new InDeathProcess() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddInDeathProcess(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new InDeathProcess() {Value = value}); 
		}

		public DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<DisableCollidersOnDeath>();

		public List<Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetBodyContactDamage(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new DisableCollidersOnDeath() { Value = new List<Collider>() }); 
		}

		public Entity AddDisableCollidersOnDeath(List<Collider> value)
		{
			return AddComponent(new DisableCollidersOnDeath() {Value = value}); 
		}

		public CurrentEnergy CurrentEnergyC => GetComponent<CurrentEnergy>();

		public ReactiveVariable<Single> CurrentEnergy => CurrentEnergyC.Value;

		public bool TryGetStartAttackRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Entity AddCurrentEnergy()
		{
			return AddComponent(new CurrentEnergy() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddCurrentEnergy(ReactiveVariable<Single> value)
		{
			return AddComponent(new CurrentEnergy() {Value = value}); 
		}

		public MaxEnergy MaxEnergyC => GetComponent<MaxEnergy>();

		public ReactiveVariable<Single> MaxEnergy => MaxEnergyC.Value;

		public bool TryGetStartAttackEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Entity AddMaxEnergy()
		{
			return AddComponent(new MaxEnergy() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddMaxEnergy(ReactiveVariable<Single> value)
		{
			return AddComponent(new MaxEnergy() {Value = value}); 
		}

		public EnergyRechargeCoefficient EnergyRechargeCoefficientC => GetComponent<EnergyRechargeCoefficient>();

		public ReactiveVariable<Single> EnergyRechargeCoefficient => EnergyRechargeCoefficientC.Value;

		public Entity AddEnergyRechargeCoefficient()
		{
			return AddComponent(new EnergyRechargeCoefficient() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetCanStartAttack(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddEnergyRechargeCoefficient(ReactiveVariable<Single> value)
		{
			return AddComponent(new EnergyRechargeCoefficient() {Value = value}); 
		}

		public EnergyRechargeInitialTime EnergyRechargeInitialTimeC => GetComponent<EnergyRechargeInitialTime>();

		public ReactiveVariable<Single> EnergyRechargeInitialTime => EnergyRechargeInitialTimeC.Value;

		public bool TryGetEndAttackEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Entity AddEnergyRechargeInitialTime()
		{
			return AddComponent(new EnergyRechargeInitialTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddEnergyRechargeInitialTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new EnergyRechargeInitialTime() {Value = value}); 
		}

		public EnergyRechargeCurrentTime EnergyRechargeCurrentTimeC => GetComponent<EnergyRechargeCurrentTime>();

		public ReactiveVariable<Single> EnergyRechargeCurrentTime => EnergyRechargeCurrentTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddEnergyRechargeCurrentTime()
		{
			return AddComponent(new EnergyRechargeCurrentTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddEnergyRechargeCurrentTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new EnergyRechargeCurrentTime() {Value = value}); 
		}

		public InEnergyRechargeCooldown InEnergyRechargeCooldownC => GetComponent<InEnergyRechargeCooldown>();

		public ReactiveVariable<Boolean> InEnergyRechargeCooldown => InEnergyRechargeCooldownC.Value;

		public bool TryGetAttackProcessCurrentTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddInEnergyRechargeCooldown()
		{
			return AddComponent(new InEnergyRechargeCooldown() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddInEnergyRechargeCooldown(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new InEnergyRechargeCooldown() {Value = value}); 
		}

		public EnergyRechargeCooldownEndEvent EnergyRechargeCooldownEndEventC => GetComponent<EnergyRechargeCooldownEndEvent>();

		public ReactiveEvent EnergyRechargeCooldownEndEvent => EnergyRechargeCooldownEndEventC.Value;

		public bool TryGetInAttackProcess(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Entity AddEnergyRechargeCooldownEndEvent()
		{
			return AddComponent(new EnergyRechargeCooldownEndEvent() { Value = new ReactiveEvent() }); 
		}

		public Entity AddEnergyRechargeCooldownEndEvent(ReactiveEvent value)
		{
			return AddComponent(new EnergyRechargeCooldownEndEvent() {Value = value}); 
		}

		public BodyContactDamage BodyContactDamageC => GetComponent<BodyContactDamage>();

		public ReactiveVariable<Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetAttackDelayTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddBodyContactDamage()
		{
			return AddComponent(new BodyContactDamage() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddBodyContactDamage(ReactiveVariable<Single> value)
		{
			return AddComponent(new BodyContactDamage() {Value = value}); 
		}

		public StartAttackRequest StartAttackRequestC => GetComponent<StartAttackRequest>();

		public ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetAttackDelayEndEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Entity AddStartAttackRequest()
		{
			return AddComponent(new StartAttackRequest() { Value = new ReactiveEvent() }); 
		}

		public Entity AddStartAttackRequest(ReactiveEvent value)
		{
			return AddComponent(new StartAttackRequest() {Value = value}); 
		}

		public StartAttackEvent StartAttackEventC => GetComponent<StartAttackEvent>();

		public ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetInstantAttackDamage(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddStartAttackEvent()
		{
			return AddComponent(new StartAttackEvent() { Value = new ReactiveEvent() }); 
		}

		public Entity AddStartAttackEvent(ReactiveEvent value)
		{
			return AddComponent(new StartAttackEvent() {Value = value}); 
		}

		public CanStartAttack CanStartAttackC => GetComponent<CanStartAttack>();

		public ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Entity AddCanStartAttack(ICompositeCondition value)
		{
			return AddComponent(new CanStartAttack() {Value = value}); 
		}

		public EndAttackEvent EndAttackEventC => GetComponent<EndAttackEvent>();

		public ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public Entity AddEndAttackEvent()
		{
			return AddComponent(new EndAttackEvent() { Value = new ReactiveEvent() }); 
		}

		public bool TryGetMustCancelAttack(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddEndAttackEvent(ReactiveEvent value)
		{
			return AddComponent(new EndAttackEvent() {Value = value}); 
		}

		public AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<AttackProcessInitialTime>();

		public ReactiveVariable<Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackCanceledEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new AttackProcessInitialTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddAttackProcessInitialTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new AttackProcessInitialTime() {Value = value}); 
		}

		public AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<AttackProcessCurrentTime>();

		public ReactiveVariable<Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new AttackProcessCurrentTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddAttackProcessCurrentTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new AttackProcessCurrentTime() {Value = value}); 
		}

		public InAttackProcess InAttackProcessC => GetComponent<InAttackProcess>();

		public ReactiveVariable<Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetAttackCooldownCurrentTime(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Entity AddInAttackProcess()
		{
			return AddComponent(new InAttackProcess() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddInAttackProcess(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new InAttackProcess() {Value = value}); 
		}

		public AttackDelayTime AttackDelayTimeC => GetComponent<AttackDelayTime>();

		public ReactiveVariable<Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetInAttackCooldown(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Entity AddAttackDelayTime()
		{
			return AddComponent(new AttackDelayTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddAttackDelayTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new AttackDelayTime() {Value = value}); 
		}

		public AttackDelayEndEvent AttackDelayEndEventC => GetComponent<AttackDelayEndEvent>();

		public ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetTakeDamageRequest(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new AttackDelayEndEvent() { Value = new ReactiveEvent() }); 
		}

		public Entity AddAttackDelayEndEvent(ReactiveEvent value)
		{
			return AddComponent(new AttackDelayEndEvent() {Value = value}); 
		}

		public InstantAttackDamage InstantAttackDamageC => GetComponent<InstantAttackDamage>();

		public ReactiveVariable<Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public Entity AddInstantAttackDamage()
		{
			return AddComponent(new InstantAttackDamage() { Value = new ReactiveVariable<Single>() }); 
		}

		public bool TryGetTakeDamageEvent(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Entity AddInstantAttackDamage(ReactiveVariable<Single> value)
		{
			return AddComponent(new InstantAttackDamage() {Value = value}); 
		}

		public ShootPoint ShootPointC => GetComponent<ShootPoint>();

		public Transform ShootPoint => ShootPointC.Value;

		public Entity AddShootPoint(Transform value)
		{
			return AddComponent(new ShootPoint() {Value = value}); 
		}

		public MustCancelAttack MustCancelAttackC => GetComponent<MustCancelAttack>();

		public ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetCanApplyDamage(out _Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Entity AddMustCancelAttack(ICompositeCondition value)
		{
			return AddComponent(new MustCancelAttack() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<_Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = value}); 
		}

		public AttackCanceledEvent AttackCanceledEventC => GetComponent<AttackCanceledEvent>();

		public ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public Entity AddAttackCanceledEvent()
		{
			return AddComponent(new AttackCanceledEvent() { Value = new ReactiveEvent() }); 
		}

		public Entity AddAttackCanceledEvent(ReactiveEvent value)
		{
			return AddComponent(new AttackCanceledEvent() {Value = value}); 
		}

		public AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<AttackCooldownInitialTime>();

		public ReactiveVariable<Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new AttackCooldownInitialTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddAttackCooldownInitialTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new AttackCooldownInitialTime() {Value = value}); 
		}

		public AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<AttackCooldownCurrentTime>();

		public ReactiveVariable<Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new AttackCooldownCurrentTime() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddAttackCooldownCurrentTime(ReactiveVariable<Single> value)
		{
			return AddComponent(new AttackCooldownCurrentTime() {Value = value}); 
		}

		public InAttackCooldown InAttackCooldownC => GetComponent<InAttackCooldown>();

		public ReactiveVariable<Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public Entity AddInAttackCooldown()
		{
			return AddComponent(new InAttackCooldown() { Value = new ReactiveVariable<Boolean>() }); 
		}

		public Entity AddInAttackCooldown(ReactiveVariable<Boolean> value)
		{
			return AddComponent(new InAttackCooldown() {Value = value}); 
		}

		public BlowRadius BlowRadiusC => GetComponent<BlowRadius>();

		public ReactiveVariable<Single> BlowRadius => BlowRadiusC.Value;

		public Entity AddBlowRadius()
		{
			return AddComponent(new BlowRadius() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddBlowRadius(ReactiveVariable<Single> value)
		{
			return AddComponent(new BlowRadius() {Value = value}); 
		}

		public BlowDamage BlowDamageC => GetComponent<BlowDamage>();

		public ReactiveVariable<Single> BlowDamage => BlowDamageC.Value;

		public Entity AddBlowDamage()
		{
			return AddComponent(new BlowDamage() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddBlowDamage(ReactiveVariable<Single> value)
		{
			return AddComponent(new BlowDamage() {Value = value}); 
		}

		public TakeDamageRequest TakeDamageRequestC => GetComponent<TakeDamageRequest>();

		public ReactiveEvent<Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public Entity AddTakeDamageRequest()
		{
			return AddComponent(new TakeDamageRequest() { Value = new ReactiveEvent<Single>() }); 
		}

		public Entity AddTakeDamageRequest(ReactiveEvent<Single> value)
		{
			return AddComponent(new TakeDamageRequest() {Value = value}); 
		}

		public TakeDamageEvent TakeDamageEventC => GetComponent<TakeDamageEvent>();

		public ReactiveEvent<Single> TakeDamageEvent => TakeDamageEventC.Value;

		public Entity AddTakeDamageEvent()
		{
			return AddComponent(new TakeDamageEvent() { Value = new ReactiveEvent<Single>() }); 
		}

		public Entity AddTakeDamageEvent(ReactiveEvent<Single> value)
		{
			return AddComponent(new TakeDamageEvent() {Value = value}); 
		}

		public CanApplyDamage CanApplyDamageC => GetComponent<CanApplyDamage>();

		public ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public Entity AddCanApplyDamage(ICompositeCondition value)
		{
			return AddComponent(new CanApplyDamage() {Value = value}); 
		}

		public RandomTargetRadius RandomTargetRadiusC => GetComponent<RandomTargetRadius>();

		public ReactiveVariable<Single> RandomTargetRadius => RandomTargetRadiusC.Value;

		public Entity AddRandomTargetRadius()
		{
			return AddComponent(new RandomTargetRadius() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddRandomTargetRadius(ReactiveVariable<Single> value)
		{
			return AddComponent(new RandomTargetRadius() {Value = value}); 
		}

		public MustGenerateRandomTargetEvent MustGenerateRandomTargetEventC => GetComponent<MustGenerateRandomTargetEvent>();

		public ReactiveEvent<ReactiveVariable<Vector3>> MustGenerateRandomTargetEvent => MustGenerateRandomTargetEventC.Value;

		public Entity AddMustGenerateRandomTargetEvent()
		{
			return AddComponent(new MustGenerateRandomTargetEvent() { Value = new ReactiveEvent<ReactiveVariable<Vector3>>() }); 
		}

		public Entity AddMustGenerateRandomTargetEvent(ReactiveEvent<ReactiveVariable<Vector3>> value)
		{
			return AddComponent(new MustGenerateRandomTargetEvent() {Value = value}); 
		}

		public RigidbodyComponent RigidbodyC => GetComponent<RigidbodyComponent>();

		public Rigidbody Rigidbody => RigidbodyC.Value;

		public Entity AddRigidbody(Rigidbody value)
		{
			return AddComponent(new RigidbodyComponent() {Value = value}); 
		}

		public TransformComponent TransformC => GetComponent<TransformComponent>();

		public Transform Transform => TransformC.Value;

		public Entity AddTransform(Transform value)
		{
			return AddComponent(new TransformComponent() {Value = value}); 
		}

		public IDComponent IDC => GetComponent<IDComponent>();

		public String ID => IDC.Value;

		public Entity AddID(String value)
		{
			return AddComponent(new IDComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent TransformC => GetComponent<_Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent() {Value = value}); 
		}

	}
}
