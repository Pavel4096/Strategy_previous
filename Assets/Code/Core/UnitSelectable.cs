using Abstractions;
using Abstractions.Commands;
using UnityEngine;

namespace Core
{
    public sealed class UnitSelectable : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _selection;
        private float _health;

        public bool Selected
        {
            set => _selection.SetActive(value);
        }

        public float MaxHealth => _maxHealth;
        public float Health => _health;
        public Sprite Icon => _icon;
    }
}
