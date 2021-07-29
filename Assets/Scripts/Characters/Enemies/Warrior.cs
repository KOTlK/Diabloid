using UnityEngine;

namespace Game.Characters.AI
{
    public class Warrior : Enemy
    {
        protected Warrior (Race race, Specialization spec) : base(race, spec)
        {
            Type = AIType.Warrior;
        }

        private void Awake()
        {
            Initialize(Race.Orc, Specialization.Warrior);
            BaseAwake();
            Damage = Provider.GetStats().Strength;
        }

        private void Update()
        {
            _ai.Update();
            Debug.DrawRay(transform.position, transform.right * 100);
        }
    }
}