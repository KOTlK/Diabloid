using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Storages
{
    public class Storage<T>
        where T : Component
    {
        private Transform[] _objects;
        private List<T> _components;

        public Storage(Transform[] objects)
        {
            _objects = objects;
            _components = new List<T>();
            foreach (Transform obj in _objects)
            {
                _components.Add(obj.GetComponent<T>());
            }
        }

        public T GetItemByName(string name)
        {
            foreach(T component in _components)
            {
                if (component.name == name)
                {
                    return component;
                }
            }
            return null;
        }
    }
}

