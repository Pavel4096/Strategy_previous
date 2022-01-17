using Abstractions;
using Abstractions.Commands;
using UserControl.Commands;
using Utils;
using Zenject;
using System;

namespace UserControl.Model
{
    public sealed class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _assetsContext;
        private Action<IAttackCommand> _commandCallback;

        [Inject]
        private void Init(AttackableValue attackableValue) => attackableValue.ValueChanged += ClickedAttackable;

        public override void SpecificCommandCreation(Action<IAttackCommand> callback)
            => _commandCallback = callback;
        
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _commandCallback = null;
        }

        private void ClickedAttackable(IAttackable attackable)
        {
            _commandCallback?.Invoke(_assetsContext.Inject(new AttackCommand(attackable)));
            _commandCallback = null;
        }
    }
}
