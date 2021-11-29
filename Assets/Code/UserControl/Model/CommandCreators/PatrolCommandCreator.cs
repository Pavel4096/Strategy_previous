using Abstractions.Commands;
using UserControl.Commands;
using Utils;
using Zenject;
using System;

namespace UserControl.Model
{
    public sealed class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _assetsContext;

        public override void SpecificCommandCreation(Action<IPatrolCommand> callback) => callback?.Invoke(_assetsContext.Inject(new PatrolCommand()));
    }
}
