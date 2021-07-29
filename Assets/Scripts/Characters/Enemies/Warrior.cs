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
            Initialize(_race, _spec);
            BaseAwake();
            Damage = Provider.GetStats().Strength;
        }

        private void Update()
        {
            Debug.Log($" Enemy: Strength - {Provider.GetStats().Strength}, " +
                $"Dexterity - {Provider.GetStats().Dexterity}, " +
                $"Endurance - {Provider.GetStats().Endurance}, " +
                $"Charisma - {Provider.GetStats().Charisma}, " +
                $"Intelegence - {Provider.GetStats().Intelegence}, " +
                $"Luck - {Provider.GetStats().Luck}");
            _ai.Update();
            Debug.DrawRay(transform.position, transform.right * 100);
        }
    }
}