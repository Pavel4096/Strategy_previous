using Abstractions;
using System;
using UnityEngine;

namespace UserControl.Model
{
    [CreateAssetMenu(fileName = "SelectedValue", menuName = "Game/Selected Value")]
    public sealed class SelectedValue : ValueBase<ISelectable>
    {}
}
