namespace Game.Characters.AI.Utils
{
    public class Translators 
    {
        public AITypeBySpecialization AITypeBySpec;
        public DamageTypeBySpecialization DamageTypeBySpec;
        
        public Translators()
        {
            AITypeBySpec = new AITypeBySpecialization();
            DamageTypeBySpec = new DamageTypeBySpecialization();
        }
    }
}