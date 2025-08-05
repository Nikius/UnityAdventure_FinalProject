namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection RotationDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed RotationSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<_Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() { Value = new _Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(_Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.RigidbodyComponent RigidbodyC => GetComponent<_Project.Develop.Runtime.Gameplay.EntitiesCore.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.RigidbodyComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CharacterControllerComponent CharacterControllerC => GetComponent<_Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CharacterControllerComponent() {Value = value}); 
		}

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent TransformC => GetComponent<_Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public _Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new _Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransformComponent() {Value = value}); 
		}

	}
}
