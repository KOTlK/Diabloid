namespace Game.Characters.AI
{
    public class AI
    {
        private readonly AIType _type;
        private AIBehaviour _behaviour;
        private readonly Enemy _entity;
        private readonly Movement _entityMover;

        public AI(AIType aiType, Enemy entity, Movement entityMover)
        {
            _type = aiType;
            _entity = entity;
            _entityMover = entityMover;
            SelectBehaviour();
        }

        public void Update()
        {
            _behaviour.UpdateLogic();
        }


        private void SelectBehaviour()
        {
            switch (_type)
            {
                case AIType.Warrior:
                    _behaviour = new WarriorBehaviour(_entity, _entityMover);
                    break;
                case AIType.Mage:
                    _behaviour = new MageBehaviour(_entity, _entityMover);
                    break;
                case AIType.Thief:
                    _behaviour = new ThiefBehaviour(_entity, _entityMover);
                    break;
                default:
                    throw new System.NotImplementedException($"Behaviour {_type} is not implemented yet");
            }
        }

    }
}