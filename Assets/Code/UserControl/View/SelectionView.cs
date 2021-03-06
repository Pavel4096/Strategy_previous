using Abstractions;
using UnityEngine;

namespace UserControl.View
{
    public sealed class SelectionView : MonoBehaviour, ISelectionView
    {
        [SerializeField] private GameObject _selection;

        public void SetSelected(bool value)
        {
            _selection.SetActive(value);
        }
    }
}
