using System.Collections;
using UnityEngine;

namespace Game.Characters.AI
{
    public class TargetFinder
    {
        public bool Searching { get; private set; } = false;
        private Coroutine _searchRoutine;
        private Player _currentTarget;
        private readonly Enemy _entity;
        private Collider[] _aroundColliders = new Collider[5];
        private readonly float _searchDistance;

        public TargetFinder(Enemy bindedEntity, float searchDistance)
        {
            _entity = bindedEntity;
            _searchDistance = searchDistance;
        }

        public float GetSqrDistanceToTarget()
        {
            if (_currentTarget != null)
            {
                return (_currentTarget.transform.position - _entity.transform.position).sqrMagnitude;
            } else
            {
                return 0;
            }
        }

        public void StartSearch(float delay)
        {
            _searchRoutine = _entity.StartCoroutine(SearchForTarget(delay));
            Searching = true;
        }

        public void StopSearch()
        {
            if (_searchRoutine != null)
            {
                _entity.StopCoroutine(_searchRoutine);
                _searchRoutine = null;
                Searching = false;
            }
        }

        public Player GetCurrentTarget()
        {
            if (_currentTarget != null)
            {
                return _currentTarget;
            } else
            {
                return null;
            }
        }

        private bool InFieldOfView(Vector3 target)
        {
            var vectorToTarget = target - _entity.transform.position;
            var entityLookDirection = _entity.transform.right * _searchDistance;
            var scalar = Vector3.Dot(vectorToTarget, entityLookDirection);
            Debug.Log(scalar);
            if (scalar > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }


        private void LocateTarget(float distance)
        {
            var collidersAmount = Physics.OverlapSphereNonAlloc(_entity.transform.position, distance, _aroundColliders);
            if (collidersAmount > 0)
            {
                foreach (Collider c in _aroundColliders)
                {
                    if (c != null)
                    {
                        if (c.transform.parent != null)
                        {
                            if (c.transform.parent.TryGetComponent<Player>(out Player player))
                            {
                                if (InFieldOfView(player.transform.position))
                                {
                                    _currentTarget = player;
                                }
                                
                            }
                            else
                            {
                                _currentTarget = null;
                            }
                        }
                    }
                }
            }
        }

        private IEnumerator SearchForTarget(float delay)
        {
            while (true)
            {
                LocateTarget(_searchDistance);
                yield return new WaitForSeconds(delay);
            }
        }




        /*private void LocateTarget(float distance)
        {
            var collidersAmount = Physics.OverlapSphereNonAlloc(_entity.transform.position, distance, _aroundColliders);
            Debug.Log(collidersAmount);
            if (collidersAmount > 0)
            {
                foreach (Collider c in _aroundColliders)
                {
                    if (c != null)
                    {
                        if (c.transform.parent != null)
                        {
                            if (c.transform.parent.TryGetComponent<Player>(out Player player))
                            {
                                _currentTarget = player;
                            }
                            else
                            {
                                _currentTarget = null;
                            }
                        }
                    }
                }
            }
        }*/
    }
}