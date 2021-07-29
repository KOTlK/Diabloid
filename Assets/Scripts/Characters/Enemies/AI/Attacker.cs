using System.Collections;
using UnityEngine;
using Game.Weapon;
using Game.Characters.AI.Utils;

namespace Game.Characters.AI
{
    public class Attacker 
    {
        private readonly Enemy _entity;
        private readonly Translators _translator;

        private Coroutine _attackingRoutine;
        private Character Target => _entity.TargetLocator.GetCurrentTarget();

        public Attacker(Enemy entity)
        {
            _entity = entity;
            _translator = new Translators();
        }

        public void StartAttacking(float attackDelay)
        {
            if (_attackingRoutine == null)
            {
                _attackingRoutine = _entity.StartCoroutine(AttackCoroutine(attackDelay));
            }
            
        }

        public void StopAttack()
        {
            if (_attackingRoutine != null)
            {
                _entity.StopCoroutine(_attackingRoutine);
                _attackingRoutine = null;
            }
        }

        private IEnumerator AttackCoroutine(float attackDelay)
        {
            while (Target.Dead == false)
            {
                Attack(Target, _translator.DamageTypeBySpec.Translate(_entity.Specialization), _entity.Damage);
                yield return new WaitForSeconds(attackDelay);
            }

            StopAttack();
        }

        private void Attack(IKillable target, DamageType damageType, int damage)
        {
            target.ApplyDamage(damageType, damage);
        }
    }
}