using System.Collections;
using UnityEngine;

namespace Game.Characters.Spells
{
    public class IncreaseStrength : TempStatsModifier
    {
        public IncreaseStrength(IStatsProvider wrappedEntity, Character character) : base(wrappedEntity, character)
        {
            Name = "God Strength";
            Duration = 10f;
        }

        protected override CharacterStats IncreasedStats()
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