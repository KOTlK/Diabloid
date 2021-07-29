using UnityEngine;

namespace Game.Characters
{
    public class Player : Character
    {
        private PlayerControl _controls;
        protected Player(Race race, Specialization specialization) : base(race, specialization)
        {
            
        }

        private void Awake()
        {
            Initialize(Race.Hobbit, Specialization.Thief);
            BaseAwake();
        }

        private void Start()
        {
            _controls = new PlayerControl();
        }

        private void Update()
        {
            _controls.UpdateInput();
            Debug.Log($"Strength - {Provider.GetStats().Strength}, " +
                $"Dexterity - {Provider.GetStats().Dexterity}, " +
                $"Endurance - {Provider.GetStats().Endurance}, " +
                $"Charisma - {Provider.GetStats().Charisma}, " +
                $"Intelegence - {Provider.GetStats().Intelegence}, " +
                $"Luck - {Provider.GetStats().Luck}");

            Debug.Log($"Health - {Health}," +
                      $"Armour - {Armour}" +
                      $"Magic - {Magic}");
        }

        
    }
}