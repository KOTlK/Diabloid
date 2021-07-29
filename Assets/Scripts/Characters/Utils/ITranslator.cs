using System.Collections;
using UnityEngine;

namespace Game.Characters.AI.Utils
{
    public interface ITranslator<F,T>
    {
        public T Translate(F from);
    }
}