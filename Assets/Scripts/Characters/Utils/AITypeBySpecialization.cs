namespace Game.Characters.AI.Utils
{
    public class AITypeBySpecialization : ITranslator<Specialization, AIType>
    {
        public AIType Translate(Specialization spec) => spec switch
        {
            Specialization.Mage => AIType.Mage,
            Specialization.Warrior => AIType.Warrior,
            Specialization.Thief => AIType.Thief,
            _ => throw new System.NotImplementedException($"Specialization {spec} is not implemented yet")
        };
    }
}