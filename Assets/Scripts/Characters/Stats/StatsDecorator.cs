using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    public abstract class StatsDecorator : IStatsProvider
    {
        protected IStatsProvider WrappedEntity;

        protected StatsDecorator(IStatsProvider wrappedEntity)
        {
            WrappedEntity = wrappedEntity;
        }

        public CharacterStats GetStats()
        {
            return GetStatsInternal();
        }

        protected abstract CharacterStats GetStatsInternal();
    }
}