using System.Collections;
using UnityEngine;
using Game.Characters;

namespace Game.Characters.Spells
{
    public abstract class Spell : StatsDecorator
    {
        public string Name { get; protected set; }
        public Spell(IStatsProvider wrappedEntity) : base(wrappedEntity)
        {

        }

        protected override CharacterStats GetStatsInternal()
        {
            throw new System.NotImplementedException();
        }

    }
}