using System;
using UnityEngine;

namespace UserControl.Model
{
    public class ValueBase<T> : ScriptableObject
    {
        public T Value { get; private set; }
        public event Action<T> ValueChanged;

        public void ChangeValue(T newValue)
        {
            Value = newValue;
            ValueChanged?.Invoke(newValue);
        }
    }
}
