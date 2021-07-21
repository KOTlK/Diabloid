using System.Collections;
using UnityEngine;

namespace Game.Characters.Spells
{
    public abstract class ContinuousSpell : Spell
    {
        public float Duration;
        protected Character Target;
        protected Coroutine SpellCoroutine;

        public ContinuousSpell(IStatsProvider wrappedEntity, Character target) : base(wrappedEntity)
        {
            Target = target;
        }

        protected override CharacterStats GetStatsInternal()
        {
            throw new System.NotImplementedException();
        }

        protected abstract IEnumerator ApplySpellEffect();
    }
}