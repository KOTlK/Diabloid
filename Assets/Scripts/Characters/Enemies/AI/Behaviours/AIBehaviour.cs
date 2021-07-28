using System.Collections;
using UnityEngine;

namespace Game.Characters.AI
{
    public abstract class AIBehaviour
    {
        protected Enemy Entity;
        protected Movement EntityMover;
        public AIBehaviour(Enemy entity, Movement entityMover)
        {
            Entity = entity;
            EntityMover = entityMover;
        }
        public abstract void UpdateLogic();
    }
}