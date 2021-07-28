using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    // делаю движение на отъебись, как и всё здесь )))000))))
    public class Movement
    {
        private const float _nearDistance = 4f;
        private const float _gravityModifier = 1f;
        private Character _entity;
        private float _speed;

        private Vector3 _targetVelocity;
        private Vector3 _velocity;
        private float _sqrDistanceToDestination;

        private Coroutine _movementCoroutine;
        private Rigidbody _entityRigidBody;

        public Movement(Character entity)
        {
            _entity = entity;
            _speed = _entity.Provider.GetStats().Dexterity * 100f;
            _entityRigidBody = _entity.GetComponent<Rigidbody>();
        }

        public void MoveTo(Vector3 destination)
        {
            if (_movementCoroutine != null)
            {
                _entity.StopCoroutine(_movementCoroutine);
                _movementCoroutine = _entity.StartCoroutine(MoveRoutine(destination));
            } else
            {
                _movementCoroutine = _entity.StartCoroutine(MoveRoutine(destination));
            }
        }

        public void StopMoving()
        {
            if (_movementCoroutine != null)
            {
                _entity.StopCoroutine(_movementCoroutine);
                _movementCoroutine = null;
            }
        }

        private IEnumerator MoveRoutine(Vector3 destination)
        {
            _sqrDistanceToDestination = (destination - _entity.transform.position).sqrMagnitude;

            while (_sqrDistanceToDestination > _nearDistance * _nearDistance)
            {
                _sqrDistanceToDestination = (destination - _entity.transform.position).sqrMagnitude;
                _targetVelocity = (destination - _entity.transform.position).normalized * _speed;
                _targetVelocity *= Time.deltaTime;
                _targetVelocity.y = Physics.gravity.y * _gravityModifier;
                _velocity = _targetVelocity;
                 
                _entityRigidBody.velocity = _velocity;
                yield return null;
            }

            if (_movementCoroutine != null)
            {
                _movementCoroutine = null;
            }
        }
    }
}