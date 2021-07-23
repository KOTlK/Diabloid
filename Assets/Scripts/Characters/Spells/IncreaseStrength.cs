﻿using System.Collections;
using UnityEngine;
using Game.Characters;

namespace Game.Characters.Spells
{
    public class IncreaseStrength : ContinuousSpell
    {
        public IncreaseStrength(IStatsProvider wrappedEntity, Character character) : base(wrappedEntity, character)
        {
            Name = "God Strength";
            Duration = 10f;
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