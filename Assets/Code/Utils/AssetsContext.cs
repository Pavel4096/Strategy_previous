using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    [CreateAssetMenu(fileName = "AssetsContext", menuName = "Game/Assets Context")]
    public sealed class AssetsContext : ScriptableObject
    {
        [SerializeField] private Object[] _objects;

        public Object GetObjectOfType(Type type, string name = null)
        {
            for(var i = 0; i < _objects.Length; i++)
            {
                Object obj = _objects[i];
                if(obj.GetType().IsAssignableFrom(type))
                {
                    if(name == null || name == obj.name)
                        return obj;
                }
            }

            return null;
        }
    }
}
