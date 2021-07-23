using System.Collections;
using UnityEngine;

namespace Game.Characters.Spells
{
    public class IncreaseLuck : ContinuousSpell
    {
        public IncreaseLuck(IStatsProvider wrappedEntity, Character character) : base(wrappedEntity, character)
        {
            Name = "Wish you luck";
            Duration = 5f;
        }


        protected override IEnumerator ApplySpellEffect()
        {
            while (Duration > 0)
            {
                _newStats = _startStats + IncreasedStats();
                Duration--;
                yield return new WaitForSeconds(1f);
            }
            if (SpellCoroutine != null)
            {
                Target.StopCoroutine(SpellCoroutine);
            }
        }

        private CharacterStats IncreasedStats()
        {
            return new CharacterStats()
            {
                Strength = 0,
                Dexterity = 0,
                Endurance = 0,
                Intelegence = 0,
                Charisma = 0,
                Luck = 10
            };
        }
    }
}