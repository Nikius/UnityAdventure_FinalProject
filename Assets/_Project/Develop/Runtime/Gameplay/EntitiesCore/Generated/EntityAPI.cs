using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Common;
using _Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
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

	}
}
