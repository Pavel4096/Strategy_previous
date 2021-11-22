using UserControl.Model;
using Abstractions;
using UnityEngine;

namespace UserControl.Presenter
{
    public sealed class SelectionPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedValue _selectedValue;
        private ISelectable _currentSelection;

        private void Awake()
        {
            _selectedValue.SelectionChanged += ChangeSelection;
        }

        private void OnDestroy()
        {
            _selectedValue.SelectionChanged -= ChangeSelection;
        }

        private void ChangeSelection(ISelectable selectable)
        {
            if(_currentSelection != null)
                _currentSelection.Selected = false;
            
            _currentSelection = selectable;

            if(selectable != null)
            selectable.Selected = true;
        }
    }
}
