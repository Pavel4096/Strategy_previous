using Abstractions;
using UnityEngine;

namespace UserControl.Model
{
    [CreateAssetMenu(fileName = "AttackableValue", menuName = "Game/Attackable Value")]
    public sealed class AttackableValue : ValueBase<IAttackable>
    {}
}
