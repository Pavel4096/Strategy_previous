using UserControl.Model;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserControl.Presenter
{
    public sealed class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedValue _selectedValue;
        [SerializeField] private Vector3Value _vector3Value;
        [SerializeField] private EventSystem _eventSystem;
        private Camera _camera;
        private RaycastHit[] hits;
        private int _groundLayer;

        private const int _leftMouseButton = 0;
        private const int _rightMouseButton = 1;
        private const string _groundLayerName = "Ground";

        private void Awake()
        {
            _camera = Camera.main;
            hits = new RaycastHit[5];
            _groundLayer = LayerMask.NameToLayer(_groundLayerName);
        }

        private void Update()
        {   
            if(_eventSystem.IsPointerOverGameObject())
                return;

            if(Input.GetMouseButtonUp(_leftMouseButton))
            {
                var count = Physics.RaycastNonAlloc(_camera.ScreenPointToRay(Input.mousePosition), hits);

                bool selectionFound = false;
                for(var i = 0; i < count; i++)
                {
                    ISelectable currentSelectable = hits[i].collider.GetComponentInParent<ISelectable>();
                    if(currentSelectable == null)
                        continue;
                
                    _selectedValue.ChangeValue(currentSelectable);
                    selectionFound = true;
                    break;
                }

                if(!selectionFound)
                    _selectedValue.ChangeValue(null);
            }
            else if(Input.GetMouseButtonUp(_rightMouseButton))
            {
                if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if(hit.transform.gameObject.layer == _groundLayer)
                        _vector3Value.ChangeValue(hit.point);
                }
            }
        }
    }
}
