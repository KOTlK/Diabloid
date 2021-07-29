using Game.Weapon;

namespace Game.Characters.AI.Utils
{
    public class DamageTypeBySpecialization : ITranslator<Specialization, DamageType>
    {
        public DamageType Translate(Specialization spec) => spec switch
        {
            Specialization.Mage => DamageType.Magic,
            Specialization.Warrior => DamageType.Physical,
            Specialization.Thief => DamageType.Physical,
            _ => throw new System.NotImplementedException($"Specialization {spec} is not implemented yet!")
        };
    }
}