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
            if (_objects.Length > 0)
            {
                foreach (Transform obj in _objects)
                {
                    _components.Add(obj.GetComponent<T>());
                }
            }
            
        }

        public T GetItemByName(string name)
        {
            if (_components.Count > 0)
            {
                foreach (T component in _components)
                {
                    if (component.name == name)
                    {
                        return component;
                    }
                }
            }
            return null;
        }

        public T GetItemByIndex(int index)
        {
            if (_components.Count > 0)
            {
                return _components[index];
            } else
            {
                return null;
            }
        }

        public T GetFirstItem()
        {
            if (_components.Count > 0)
            {
                return _components[0];
            }else
            {
                return null;
            }
        }

        public T GetLastItem()
        {
            if (_components.Count > 0)
            {
                return _components[-1];
            }
            else
            {
                return null;
            }
        }
    }
}

