using System.Collections;
using UnityEngine;
using Game.Weapon;

namespace Game.Characters
{
    public interface IKillable
    {
        public void ApplyDamage(DamageType type, int amount);
    }
}