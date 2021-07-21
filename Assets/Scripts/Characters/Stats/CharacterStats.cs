using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Characters
{
    public struct CharacterStats
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
        public int Intelegence { get; set; }
        public int Charisma { get; set; }
        public int Luck { get; set; }

        public static CharacterStats operator +(CharacterStats a, CharacterStats b)
        {
            return new CharacterStats()
            {
                Strength = a.Strength + b.Strength,
                Dexterity = a.Dexterity + b.Dexterity,
                Endurance = a.Endurance + b.Endurance,
                Intelegence = a.Intelegence + b.Intelegence,
                Charisma = a.Charisma + b.Charisma,
                Luck = a.Luck + b.Luck
            };
        }

        public static CharacterStats operator *(CharacterStats a, int b)
        {
            return new CharacterStats()
            {
                Strength = a.Strength * b,
                Dexterity = a.Dexterity * b,
                Endurance = a.Endurance * b,
                Intelegence = a.Intelegence * b,
                Charisma = a.Charisma * b,
                Luck = a.Luck * b
            };
        }

        public static CharacterStats operator -(CharacterStats a, CharacterStats b)
        {
            return new CharacterStats()
            {
                Strength = a.Strength - b.Strength,
                Dexterity = a.Dexterity - b.Dexterity,
                Endurance = a.Endurance - b.Endurance,
                Intelegence = a.Intelegence - b.Intelegence,
                Charisma = a.Charisma - b.Charisma,
                Luck = a.Luck - b.Luck
            };
        }
    }
}