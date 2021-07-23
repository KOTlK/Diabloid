using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Game.Characters.Spells;

namespace Game.Characters
{
    public abstract class Character : MonoBehaviour
    {
        public List<Spell> ActiveSpells;
        public IStatsProvider Provider;
        protected IStatsProvider ClearStats;
        protected Race Race;
        protected Specialization Specialization;
        private int _maxHealth;
        private int _maxArmour;
        private int _maxMagic;
        protected int Health { get; set; }
        protected int Armour { get; set; }
        protected int Magic { get; set; }

        protected Character(Race race, Specialization specialization)
        {
            Initialize(race, specialization);
        }

        public bool NoActiveSpell(Spell spell)
        {
            foreach (Spell tempSpell in ActiveSpells)
            {
                if (tempSpell.Name == spell.Name)
                {
                    return false;

                }
            }
            return true;
        }

        public void AddSpell(Spell spell)
        {
            if (NoActiveSpell(spell))
            {
                ActiveSpells.Add(spell);
            }
        }

        protected void Initialize(Race race, Specialization specialization)
        {
            ActiveSpells = new List<Spell>();
            Race = race;
            Specialization = specialization;
            ClearStats = new RaceStats(race);
            ClearStats = new SpecializationStats(ClearStats, specialization);
            Provider = ClearStats;
        }

        protected void BaseAwake()
        {
            _maxHealth = Provider.GetStats().Strength * 10;
            _maxMagic = Provider.GetStats().Intelegence * 10;
            _maxArmour = Provider.GetStats().Endurance * 10;
            Magic = _maxMagic;
            Health = _maxHealth;
            Armour = _maxArmour;
            StartCoroutine(CheckActiveSpells());
        }

        private void Awake()
        {
            BaseAwake();
        }

        private IEnumerator CheckActiveSpells()
        {
            while (true)
            {
                if (ActiveSpells.Count == 0)
                {
                    Provider = ClearStats;
                }
                foreach (ContinuousSpell spell in ActiveSpells.ToArray())
                {
                    if (spell.Duration > 0)
                    {
                        Provider = spell;
                    } else
                    {
                        ActiveSpells.Remove(spell);
                    }
                }
                Debug.Log(ActiveSpells.Count);
                yield return new WaitForSeconds(0.2f);
            }
        }


    }
}