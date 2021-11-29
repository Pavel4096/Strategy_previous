using Abstractions.Commands;
using UserControl.Commands;
using Utils;
using Zenject;
using System;
using UnityEngine;

namespace UserControl.Model
{
    public sealed class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [SerializeField] private AssetsContext _assetsContext;
        private Action<IMoveCommand> _commandCallback;

        [Inject]
        private void Init(Vector3Value vector3Value) => vector3Value.ValueChanged += ClickedGround;

        public override void SpecificCommandCreation(Action<IMoveCommand> callback) 
            => _commandCallback = callback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _commandCallback = null;
        }

        private void ClickedGround(Vector3 position)
        {
            _commandCallback?.Invoke(_assetsContext.Inject(new MoveCommand(position)));
            _commandCallback = null;
        }
    }
}
