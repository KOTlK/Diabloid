using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    public class RaceStats : IStatsProvider
    {
        private readonly Race _raceType;

        public RaceStats(Race raceType)
        {
            _raceType = raceType;
        }


        public CharacterStats GetStats()
        {
            //default stats sum = 32
            switch (_raceType)
            {
                case Race.Human:
                    return new CharacterStats()
                    {
                        Strength = 5,
                        Dexterity = 5,
                        Endurance = 5,
                        Intelegence = 5,
                        Charisma = 5,
                        Luck = 7
                    };
                case Race.Orc:
                    return new CharacterStats()
                    {
                        Strength = 12,
                        Dexterity = 5,
                        Endurance = 8,
                        Intelegence = 1,
                        Charisma = 1,
                        Luck = 5
                    };
                case Race.Elf:
                    return new CharacterStats()
                    {
                        Strength = 4,
                        Dexterity = 7,
                        Endurance = 6,
                        Intelegence = 5,
                        Charisma = 6,
                        Luck = 4
                    };
                case Race.Hobbit:
                    return new CharacterStats()
                    {
                        Strength = 3,
                        Dexterity = 8,
                        Endurance = 6,
                        Intelegence = 4,
                        Charisma = 4,
                        Luck = 7
                    };
                default:
                    throw new System.NotImplementedException($"Race {_raceType} not implemented");
            }
        }
    }
}