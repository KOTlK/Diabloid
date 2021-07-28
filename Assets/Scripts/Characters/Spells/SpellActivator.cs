using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Characters.Spells
{
    public class SpellActivator
    {
        public int Count => _activeSpells.Count;
        private readonly Character _entity;
        private List<Spell> _activeSpells;
        private Coroutine _coroutine;
        public SpellActivator(Character entity)
        {
            _entity = entity;
            _activeSpells = new List<Spell>();
        }

        public void Start()
        {
            _coroutine = _entity.StartCoroutine(UpdateSpells());
        }

        public void Add(Spell spell)
        {
            if (NoActiveSpell(spell))
            {
                _activeSpells.Add(spell);
            }
        }

        private IEnumerator UpdateSpells()
        {
            while (true)
            {
                if (_activeSpells.Count == 0)
                {
                    _entity.Provider = _entity.ClearStats;
                } else
                {
                    foreach (TempStatsModifier continuousSpell in _activeSpells.ToArray())
                    {
                        if (continuousSpell.isActive)
                        {
                            _entity.Provider = continuousSpell;
                            Debug.Log($"Applying {continuousSpell.Name}");
                        } else
                        {
                            _activeSpells.Remove(continuousSpell);
                            Debug.Log($"Removing {continuousSpell.Name}");
                        }
                    }
                }

                yield return new WaitForSeconds(0.2f);
            }
        }

        private bool NoActiveSpell(Spell spell)
        {
            foreach (Spell tempSpell in _activeSpells)
            {
                if (tempSpell.Name == spell.Name)
                {
                    return false;

                }
            }
            return true;
        }


    }
}