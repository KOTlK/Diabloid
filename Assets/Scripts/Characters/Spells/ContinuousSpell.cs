using System.Collections;
using UnityEngine;

namespace Game.Characters.Spells
{
    public abstract class ContinuousSpell : Spell
    {
        public float Duration;
        protected Character Target;
        protected Coroutine SpellCoroutine;
        protected CharacterStats _startStats;
        protected CharacterStats _newStats;

        public ContinuousSpell(IStatsProvider wrappedEntity, Character target) : base(wrappedEntity)
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

        protected abstract IEnumerator ApplySpellEffect();
    }
}