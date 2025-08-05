using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Common;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using _Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public RotationDirection RotationDirectionC => GetComponent<RotationDirection>();

		public ReactiveVariable<Vector3> RotationDirection => RotationDirectionC.Value;

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

		public Entity AddRotationSpeed(ReactiveVariable<Single> value)
		{
			return AddComponent(new RotationSpeed() {Value = value}); 
		}

		public MoveDirection MoveDirectionC => GetComponent<MoveDirection>();

		public ReactiveVariable<Vector3> MoveDirection => MoveDirectionC.Value;

		public Entity AddMoveDirection()
		{
			return AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>() }); 
		}

		public Entity AddMoveDirection(ReactiveVariable<Vector3> value)
		{
			return AddComponent(new MoveDirection() {Value = value}); 
		}

		public MoveSpeed MoveSpeedC => GetComponent<MoveSpeed>();

		public ReactiveVariable<Single> MoveSpeed => MoveSpeedC.Value;

		public Entity AddMoveSpeed()
		{
			return AddComponent(new MoveSpeed() { Value = new ReactiveVariable<Single>() }); 
		}

		public Entity AddMoveSpeed(ReactiveVariable<Single> value)
		{
			return AddComponent(new MoveSpeed() {Value = value}); 
		}

		public RigidbodyComponent RigidbodyC => GetComponent<RigidbodyComponent>();

		public Rigidbody Rigidbody => RigidbodyC.Value;

		public Entity AddRigidbody(Rigidbody value)
		{
			return AddComponent(new RigidbodyComponent() {Value = value}); 
		}

		public CharacterControllerComponent CharacterControllerC => GetComponent<CharacterControllerComponent>();

		public CharacterController CharacterController => CharacterControllerC.Value;

		public Entity AddCharacterController(CharacterController value)
		{
			return AddComponent(new CharacterControllerComponent() {Value = value}); 
		}

		public TransformComponent TransformC => GetComponent<TransformComponent>();

		public Transform Transform => TransformC.Value;

		public Entity AddTransform(Transform value)
		{
			return AddComponent(new TransformComponent() {Value = value}); 
		}

	}
}
