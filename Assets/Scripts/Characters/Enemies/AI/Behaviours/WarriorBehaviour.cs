using UnityEngine;

namespace Game.Characters.AI
{
    public class WarriorBehaviour : AIBehaviour
    {
        private const float _searchDelay = 1f;
        private const float _attackDistance = 5f;
        private const float _attackDelay = 1f;
        private const float _maxFollowDistance = 50f;
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

            if (Entity.TargetLocator.GetSqrDistanceToTarget() > _maxFollowDistance * _maxFollowDistance)
            {
                Entity.Attacker.StopAttack();
                Entity.Mover.StopMoving();
            }

        }
    }
}