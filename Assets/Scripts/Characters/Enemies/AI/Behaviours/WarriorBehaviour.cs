using System.Collections;
using UnityEngine;

namespace Game.Characters.AI
{
    public class WarriorBehaviour : AIBehaviour
    {
        private float _searchDelay = 1f;
        private float _attackDistance = 2f;
        private float _attackDelay = 1f;
        public WarriorBehaviour(Enemy entity, Movement entityMover) : base(entity, entityMover)
        {
        }

        public override void UpdateLogic()
        {
            if (Entity.TargetLocator.Searching == false && Entity.TargetLocator.GetCurrentTarget() == null)
            {
                Entity.TargetLocator.StartSearch(_searchDelay);
            } 


            if (Entity.TargetLocator.GetCurrentTarget() != null)
            {
                Entity.TargetLocator.StopSearch();
                EntityMover.MoveTo(Entity.TargetLocator.GetCurrentTarget().transform.position);
            }


            if (Entity.TargetLocator.GetCurrentTarget() != null && Entity.TargetLocator.GetSqrDistanceToTarget() < _attackDistance * _attackDistance)
            {
                Entity.Attacker.StartAttacking(_attackDelay);
                Entity.Mover.StopMoving();
            }
        }
    }
}