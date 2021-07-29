using UnityEngine;
using Game.Characters.Spells;
using Game.Weapon;

namespace Game.Characters
{
    public abstract class Character : MonoBehaviour, IKillable
    {
        public IStatsProvider Provider;
        public int Damage { get; protected set; }
        public Race Race { get; protected set; }
        public Specialization Specialization { get; protected set; }
        public bool Dead { get; private set; } = false;
        public Movement Mover { get; private set; }
        public SpellActivator ActiveSpells { get; private set; }
        public IStatsProvider ClearStats { get; private set; }

        public delegate void OnCharacterDeath();
        public event OnCharacterDeath CharacterDied;

        protected int Health { get; set; }
        protected int Armour { get; set; }
        protected int Magic { get; set; }

        private int _maxHealth;
        private int _maxArmour;
        private int _maxMagic;

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
                            Magic = 0;
                            Health += applyedMagic;
                        }
                        else
                        {
                            Magic = applyedMagic;
                        }
                    }
                    else
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
                            Armour = 0;
                            Health += applyedDamage;
                        }
                        else
                        {
                            Armour = applyedDamage;
                        }
                    }
                    else
                    {
                        Health -= amount;
                    }
                    TryToDie();
                    break;

            }
        }

        

        protected Character(Race race, Specialization specialization)
        {
            Initialize(race, specialization);
            Dead = false;
        }


        protected void Initialize(Race race, Specialization specialization)
        {
            ActiveSpells = new SpellActivator(this);
            Race = race;
            Specialization = specialization;
            ClearStats = new RaceStats(race);
            ClearStats = new SpecializationStats(ClearStats, specialization);
            Provider = ClearStats;
            Mover = new Movement(this);
        }

        protected void BaseAwake()
        {
            _maxHealth = Provider.GetStats().Strength * 10;
            _maxMagic = Provider.GetStats().Intelegence * 10;
            _maxArmour = Provider.GetStats().Endurance * 10;
            Magic = _maxMagic;
            Health = _maxHealth;
            Armour = _maxArmour;
            ActiveSpells.Start();
        }

        private void Awake()
        {
            BaseAwake();
        }

        private void TryToDie()
        {
            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            CharacterDied?.Invoke();
            Dead = true;
            Debug.Log("DEAD");
        }

    }
}