using UnityEngine;

namespace Abstractions
{
    public interface ISelectable
    {
        float MaxHealth { get; }
        float Health { get; }
        Sprite Icon { get; }
        bool Selected { set; }
    }
}
