using Abstractions;
using Abstractions.Commands;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _selection;
        private float _health;

        public float MaxHealth => _maxHealth;
        public float Health => _health;
        public Sprite Icon => _icon;
        public bool Selected
        {
            set => _selection.SetActive(value);
        }

        private void Start()
        {
            _health = _maxHealth;
        }

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(0.0f, 8.0f), 0.0f, Random.Range(0.0f, 8.0f)), Quaternion.identity, _unitsParent);
        }
    }
}
