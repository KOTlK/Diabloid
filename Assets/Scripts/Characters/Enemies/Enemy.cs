using Game.Weapon;
using System.Collections;
using UnityEngine;

namespace Game.Characters.AI
{
    public abstract class Enemy : Character
    {
        public TargetFinder TargetLocator { get; private set; }
        public Attacker Attacker { get; private set; }

        protected AIType Type;

        private AI _ai;


        [SerializeField] private float _searchDistance = 3f;
        protected Enemy(Race race, Specialization spec) : base(race, spec)
        {

        }

        private void Start()
        {
            TargetLocator = new TargetFinder(this, _searchDistance);
            _ai = new AI(Type, this, Mover);
            Attacker = new Attacker(this);
        }

        private void Update()
        {
            _ai.Update();
        }
    }
}