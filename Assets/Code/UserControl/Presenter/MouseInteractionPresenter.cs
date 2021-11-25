using UserControl.Model;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserControl.Presenter
{
    public sealed class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedValue _selectedValue;
        [SerializeField] private EventSystem _eventSystem;
        private Camera _camera;
        private RaycastHit[] hits;

        private const int _leftMouseButton = 0;

        private void Awake()
        {
            _camera = Camera.main;
            hits = new RaycastHit[5];
        }

        private void Update()
        {
            if(!Input.GetMouseButtonUp(_leftMouseButton))
                return;
            
            if(_eventSystem.IsPointerOverGameObject())
                return;
            
            var count = Physics.RaycastNonAlloc(_camera.ScreenPointToRay(Input.mousePosition), hits);

            bool selectionFound = false;
            for(var i = 0; i < count; i++)
            {
                ISelectable currentSelectable = hits[i].collider.GetComponentInParent<ISelectable>();
                if(currentSelectable == null)
                    continue;
                
                _selectedValue.ChangeSelection(currentSelectable);
                selectionFound = true;
                break;
            }

            if(!selectionFound)
                _selectedValue.ChangeSelection(null);
        }
    }
}
