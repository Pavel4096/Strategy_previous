using Abstractions.Commands;
using UserControl.Commands;
using Utils;
using Zenject;
using System;

namespace UserControl.Model
{
    public sealed class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _assetsContext;

        public override void SpecificCommandCreation(Action<IStopCommand> callback) => callback?.Invoke(_assetsContext.Inject(new StopCommand()));
    }
}
