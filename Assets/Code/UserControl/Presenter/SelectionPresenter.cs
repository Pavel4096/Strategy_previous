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
            {
                ISelectionView currentSelection = (_currentSelection as Component).GetComponent<ISelectionView>();
                currentSelection.SetSelected(false);
                //_currentSelection.Selected = false;
            }
            
            _currentSelection = selectable;

            if(selectable != null)
            {
                ISelectionView newSelection = (selectable as Component).GetComponent<ISelectionView>();
                newSelection.SetSelected(true);
                //selectable.Selected = true;
            }
        }
    }
}
