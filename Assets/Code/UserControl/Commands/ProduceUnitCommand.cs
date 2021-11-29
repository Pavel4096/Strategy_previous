using Abstractions.Commands;
using Utils;
using UnityEngine;

namespace UserControl.Commands
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Unit0")] private GameObject _unitPrefab;
    }
}
