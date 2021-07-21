using System.Collections;
using UnityEngine;

namespace Game.Characters
{
    public interface IStatsProvider 
    {
        public CharacterStats GetStats();
    }
}