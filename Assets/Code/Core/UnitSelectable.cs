using Abstractions;
using Abstractions.Commands;
using UnityEngine;

namespace Core
{
    public sealed class UnitSelectable : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;
        private float _health;

        public float MaxHealth => _maxHealth;
        public float Health => _health;
        public Sprite Icon => _icon;

        private void Awake()
        {
            _health = _maxHealth;
        }
    }
}
