using UserControl.Model;
using UserControl.View;
using UserControl.Commands;
using Utils;
using Abstractions;
using Abstractions.Commands;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UserControl.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedValue _selectedValue;
        [SerializeField] private CommandButtonsView _commandButtonsView;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _commandButtonsView.Clear();
            _selectedValue.SelectionChanged += SelectionChanged;
            SelectionChanged(_selectedValue.Value);
            _commandButtonsView.CommandSelected += CommandSelected;
        }

        private void OnDestroy()
        {
            _selectedValue.SelectionChanged -= SelectionChanged;
            _commandButtonsView.CommandSelected -= CommandSelected;
        }

        private void SelectionChanged(ISelectable selectable)
        {
            if(selectable == _currentSelectable)
                return;
            
            _currentSelectable = selectable;
            _commandButtonsView.Clear();

            if(selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _commandButtonsView.MakeLayout(commandExecutors);
            }
        }

        private void CommandSelected(ICommandExecutor commandExecutor)
        {
            switch(commandExecutor)
            {
                case CommandExecutorBase<IMoveCommand> moveExecutor:
                    moveExecutor.ExecuteSpecificCommand(_context.Inject(new MoveCommand(new Vector3(1.0f, 2.0f, 3.0f))));
                    break;
                case CommandExecutorBase<IProduceUnitCommand> unitProducer:
                    unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand2()));
                    break;
                case CommandExecutorBase<IAttackCommand> attackExecutor:
                    attackExecutor.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                    break;
                case CommandExecutorBase<IPatrolCommand> patrolExecutor:
                    patrolExecutor.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                    break;
                case CommandExecutorBase<IStopCommand> stopExecutor:
                    stopExecutor.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                    break;
                default:
                    throw new ApplicationException($"Specified command is not implemented: {commandExecutor.GetType().FullName}");
            }
        }
    }
}
