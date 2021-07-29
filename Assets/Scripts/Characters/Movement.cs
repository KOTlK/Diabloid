using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    public class Movement
    {
        private const float _minVelovityMultiplier = 2500;
        private const float _defaultVelocityMultiplier = 3500;
        private const float _maxVelocityMultiplier = 4500;
        private const float _speedMultiplier = 100f;
        private const float _nearDistance = 2f;
        private const float _gravityModifier = 1f;
        private const float _rotationSpeed = 360f;

        private readonly Rigidbody _entityRigidBody;
        private readonly Character _entity;
        private readonly float _velocityMultiplier;

        private Vector3 _targetVelocity;
        private Vector3 _velocity;
        private float _sqrDistanceToDestination;

        private Coroutine _movementCoroutine;
        

        public Movement(Character entity)
        {
            _entity = entity;
            _velocityMultiplier = CountVelicityMultiplier(_entity.Provider.GetStats().Dexterity, _entity.Provider.GetStats().Strength);
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
            _entityRigidBody.velocity = Vector3.zero;
            if (_movementCoroutine != null)
            {
                _entity.StopCoroutine(_movementCoroutine);
                _movementCoroutine = null;
            }
        }

        private float CountVelicityMultiplier(int dexterity, int strength)
        {
            var mult = (dexterity - (strength * 0.5f)) * _speedMultiplier + _defaultVelocityMultiplier;
            if (mult < 0)
            {
                return _minVelovityMultiplier;
            } else if (mult > 0)
            {
                if (mult > _maxVelocityMultiplier)
                {
                    return _maxVelocityMultiplier;
                } else
                {
                    return mult;
                }
            } else
            {
                return _defaultVelocityMultiplier;
            }
        }


        private IEnumerator MoveRoutine(Vector3 destination)
        {
            _sqrDistanceToDestination = (destination - _entity.transform.position).sqrMagnitude;

            while (_sqrDistanceToDestination > _nearDistance * _nearDistance)
            {
                _sqrDistanceToDestination = (destination - _entity.transform.position).sqrMagnitude;

                LookAt(destination);

                _targetVelocity = (destination - _entity.transform.position).normalized;

                Physics.Raycast(_entity.transform.position, -Vector3.up, out RaycastHit hitInfo);

                //moving object along ground normal
                _targetVelocity -= Vector3.Dot(_targetVelocity, hitInfo.normal) * hitInfo.normal;
                _targetVelocity *= _velocityMultiplier * Time.deltaTime;
                _targetVelocity.y = Physics.gravity.y * _gravityModifier;
                _velocity = _targetVelocity;
                 
                _entityRigidBody.velocity = _velocity;
                yield return null;
            }

            StopMoving();

        }

        private void LookAt(Vector3 target)
        {
            float angle = -Mathf.Atan2(target.z - _entity.transform.position.z, target.x - _entity.transform.position.x) / Mathf.PI * 180f;
            float rotationAngle = _rotationSpeed * Time.deltaTime;
            float deltaAngle = Mathf.DeltaAngle(_entity.transform.eulerAngles.y, angle);
            if (Mathf.Abs(deltaAngle) < rotationAngle)
            {
                _entity.transform.eulerAngles = new Vector3(_entity.transform.eulerAngles.x, angle, _entity.transform.eulerAngles.z);
            }
            else
            {
                _entity.transform.eulerAngles += new Vector3(0, rotationAngle * Mathf.Sign(deltaAngle), 0);
            }
        }


    }
}