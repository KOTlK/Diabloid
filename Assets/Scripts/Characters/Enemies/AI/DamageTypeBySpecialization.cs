using System.Collections;
using UnityEngine;
using Game.Weapon;

namespace Game.Characters.AI
{
    public class DamageTypeBySpecialization
    {
        public static DamageType GetDamageType(Specialization spec) => spec switch
        {
            Specialization.Mage => DamageType.Magic,
            Specialization.Warrior => DamageType.Physical,
            Specialization.Thief => DamageType.Physical,
            _ => throw new System.NotImplementedException($"Specialization {spec} is not implemented yet!")
        };
    }
}