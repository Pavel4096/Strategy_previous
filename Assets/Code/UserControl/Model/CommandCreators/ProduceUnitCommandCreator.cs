using Abstractions.Commands;
using UserControl.Commands;
using Utils;
using Zenject;
using System;

namespace UserControl.Model
{
    public sealed class ProduceUnitCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _assetsContext;

        public override void SpecificCommandCreation(Action<IProduceUnitCommand> callback) => callback?.Invoke(_assetsContext.Inject(new ProduceUnitCommand()));
    }
}
