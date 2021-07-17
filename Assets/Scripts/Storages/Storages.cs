using System.Collections;
using UnityEngine;

namespace Game.Storages
{
    public class Storages : MonoBehaviour
    {
        public static Storages GameData;
        public Storage<Camera> Camera { get; private set; }

        [SerializeField] private Transform[] _camera;
        

        private void Awake()
        {
            Camera = new Storage<Camera>(_camera);

            if (GameData == null)
            {
                GameData = this;
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }
    }
}