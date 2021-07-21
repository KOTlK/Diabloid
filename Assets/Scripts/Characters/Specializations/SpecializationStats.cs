using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    public class SpecializationStats : StatsDecorator
    {
        private readonly Specialization _specialization;
        public SpecializationStats (IStatsProvider wrappedEntity, Specialization specialization) : base(wrappedEntity)
        {
            _specialization = specialization;
        }

        protected override CharacterStats GetStatsInternal()
        {
            return WrappedEntity.GetStats() + GetSpecializationStats(_specialization);
        }

        private CharacterStats GetSpecializationStats(Specialization specialization)
        {
            switch (specialization)
            {
                // sum must be 13
                case Specialization.Warrior:
                    return WrappedEntity.GetStats() + new CharacterStats()
                    {
                        Strength = 6,
                        Dexterity = 1,
                        Endurance = 6,
                        Intelegence = 0,
                        Charisma = 0,
                        Luck = 0
                    };
                case Specialization.Thief:
                    return WrappedEntity.GetStats() + new CharacterStats()
                    {
                        Strength = 0,
                        Dexterity = 6,
                        Endurance = 2,
                        Intelegence = 0,
                        Charisma = 3,
                        Luck = 2
                    };
                case Specialization.Mage:
                    return WrappedEntity.GetStats() + new CharacterStats()
                    {
                        Strength = 0,
                        Dexterity = 0,
                        Endurance = 2,
                        Intelegence = 9,
                        Charisma = 2,
                        Luck = 0
                    };
                default:
                    throw new System.NotImplementedException($"Specialization {specialization} is not implemented");
            }
        }
    }
}