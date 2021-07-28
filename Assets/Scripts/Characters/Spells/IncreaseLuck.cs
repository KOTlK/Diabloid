using System.Collections;
using UnityEngine;

namespace Game.Characters.Spells
{
    public class IncreaseLuck : TempStatsModifier
    {
        public IncreaseLuck(IStatsProvider wrappedEntity, Character character) : base(wrappedEntity, character)
        {
            Name = "Wish you luck";
            Duration = 5f;
        }



        protected override CharacterStats IncreasedStats()
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