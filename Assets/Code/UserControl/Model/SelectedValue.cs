using Abstractions;
using System;
using UnityEngine;

namespace UserControl.Model
{
    [CreateAssetMenu(fileName = "SelectedValue", menuName = "Game/Selected Value")]
    public sealed class SelectedValue : ScriptableObject
    {
        public ISelectable Value { get; private set; }
        public event Action<ISelectable> SelectionChanged;

        public void ChangeSelection(ISelectable selectable)
        {
            if(Value == selectable)
                return;
            
            Value = selectable;
            SelectionChanged?.Invoke(Value);
        }
    }
}
