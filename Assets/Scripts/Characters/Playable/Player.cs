using Game.Weapon;
using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    public class Player : Character, IKillable
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
        }



        //ужас ебаный, переписать потом
        public void ApplyDamage(DamageType type, int amount)
        {
            switch (type)
            {
                case DamageType.Magic:
                    if (Magic > 0)
                    {
                        int applyedMagic = Magic - amount;
                        if (applyedMagic < 0)
                        {
                            Health += applyedMagic;
                        }else
                        {
                            Magic = applyedMagic;
                        }
                    } else
                    {
                        Health -= amount;
                    }
                    TryToDie();
                    break;
                case DamageType.Physical:
                    if (Armour > 0)
                    {
                        int applyedDamage = Armour - amount;
                        if (applyedDamage < 0)
                        {
                            Health += applyedDamage;
                        } else
                        {
                            Armour = applyedDamage;
                        }
                    } else
                    {
                        Health -= amount;
                    }
                    TryToDie();
                    break;
            }
        }

        private void TryToDie()
        {
            if(Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("DEAD");
        }

        
    }
}