using System.Collections;
using UnityEngine;

namespace Game.Characters.Spells
{
    public abstract class TempStatsModifier : Spell
    {
        public bool isActive = true;
        protected float Duration;
        protected Character Target;
        protected Coroutine SpellCoroutine;
        protected CharacterStats _startStats;
        protected CharacterStats _newStats;

        public TempStatsModifier(IStatsProvider wrappedEntity, Character target) : base(wrappedEntity)
        {
            Target = target;
            _startStats = wrappedEntity.GetStats();
        }

        protected override CharacterStats GetStatsInternal()
        {
            if (SpellCoroutine == null)
            {
                SpellCoroutine = Target.StartCoroutine(ApplySpellEffect());
            }

            return _newStats;
        }

        private IEnumerator ApplySpellEffect()
        {
            _newStats = _startStats + IncreasedStats();
            while (Duration > 0)
            {
                isActive = true;
                Duration--;
                yield return new WaitForSeconds(1f);
            }
            isActive = false;
            _newStats -= IncreasedStats();
            if (SpellCoroutine != null)
            {
                Target.StopCoroutine(SpellCoroutine);
            }


        }

        protected virtual CharacterStats IncreasedStats()
        {
            return new CharacterStats()
            {
                Strength = 0,
                Dexterity = 0,
                Endurance = 0,
                Intelegence = 0,
                Charisma = 0,
                Luck = 0
            };
        }
    }
}