using Abstractions.Commands;
using Utils;
using Zenject;
using System;

namespace UserControl.Model
{
    public sealed class CommandButtonsModel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;

        [Inject] private CommandCreatorBase<IStopCommand> _stopCommand;
        [Inject] private CommandCreatorBase<IProduceUnitCommand> _produceUnitCommand;
        [Inject] private CommandCreatorBase<IMoveCommand> _moveCommand;
        [Inject] private CommandCreatorBase<IPatrolCommand> _patrolCommand;
        [Inject] private CommandCreatorBase<IAttackCommand> _attackCommand;

        private bool _isCommandPending;

        public void CommandButtonClicked(ICommandExecutor executor)
        {
            if(_isCommandPending)
                ProcessCancel();
            _isCommandPending = true;
            OnCommandAccepted?.Invoke(executor);

            _stopCommand.ProcessCommandCreation(executor, (command) => ProcessCommandExecution(executor, command));
            _produceUnitCommand.ProcessCommandCreation(executor, (command) => ProcessCommandExecution(executor, command));
            _moveCommand.ProcessCommandCreation(executor, (command) => ProcessCommandExecution(executor, command));
            _patrolCommand.ProcessCommandCreation(executor, (command) => ProcessCommandExecution(executor, command));
            _attackCommand.ProcessCommandCreation(executor, (command) => ProcessCommandExecution(executor, command));
        }

        public void SelectionChanged()
        {
            _isCommandPending = false;
            ProcessCancel();
        }

        private void ProcessCommandExecution(ICommandExecutor executor, object command)
        {
            executor.ExecuteCommand(command);
            _isCommandPending = false;
            OnCommandSent?.Invoke();
        }

        private void ProcessCancel()
        {
            _stopCommand.ProcessCancel();
            _produceUnitCommand.ProcessCancel();
            _moveCommand.ProcessCancel();
            _patrolCommand.ProcessCancel();
            _attackCommand.ProcessCancel();

            OnCommandCancel?.Invoke();
        }
    }
}
