using System.Collections;
using UnityEngine;
using Game.Characters;

namespace Game.Characters.Spells
{
    public class IncreaseStrength : ContinuousSpell
    {
        private CharacterStats _startStats;
        private CharacterStats _increasedStats;
        
        public IncreaseStrength(IStatsProvider wrappedEntity, Character character) : base(wrappedEntity, character)
        {
            Name = "God Strength";
            Duration = 10f;
            Target = character;
            _startStats = wrappedEntity.GetStats();
        }

        protected override CharacterStats GetStatsInternal()
        {
            if (SpellCoroutine == null)
            {
                SpellCoroutine = Target.StartCoroutine(ApplySpellEffect());
            }
                      
            
            return _increasedStats;
        }

        protected override IEnumerator ApplySpellEffect()
        {
            while (Duration > 0)
            {
                _increasedStats = _startStats + IncreasedStats();
                Duration--;
                Debug.Log("In Coroutine");
                yield return new WaitForSeconds(1f);
            }
            Debug.Log("Out of cycle");
            if (SpellCoroutine != null)
            {
                Target.StopCoroutine(SpellCoroutine);
            }

        }

        private CharacterStats IncreasedStats()
        {
            return new CharacterStats()
            {
                Strength = 10,
                Dexterity = 0,
                Endurance = 0,
                Intelegence = 0,
                Charisma = 0,
                Luck = 0

            };
        }

        
    }
}