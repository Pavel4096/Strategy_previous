using UserControl.Model;
using UserControl.View;
using UserControl.Commands;
using Utils;
using Abstractions;
using Abstractions.Commands;
using Zenject;
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
        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _commandButtonsView.CommandSelected += _model.CommandButtonClicked;
            _model.OnCommandAccepted += _commandButtonsView.BlockInteraction;
            _model.OnCommandSent += _commandButtonsView.UnblockAllInteractions;
            _model.OnCommandCancel += _commandButtonsView.UnblockAllInteractions;
            _commandButtonsView.Clear();
            _selectedValue.ValueChanged += SelectionChanged;
            SelectionChanged(_selectedValue.Value);
        }

        private void OnDestroy()
        {
            _selectedValue.ValueChanged -= SelectionChanged;
            _commandButtonsView.CommandSelected -= _model.CommandButtonClicked;
            _model.OnCommandAccepted -= _commandButtonsView.BlockInteraction;
            _model.OnCommandSent -= _commandButtonsView.UnblockAllInteractions;
            _model.OnCommandCancel -= _commandButtonsView.UnblockAllInteractions;
        }

        private void SelectionChanged(ISelectable selectable)
        {
            if(selectable == _currentSelectable)
                return;

            if(_currentSelectable != null)
                _model.SelectionChanged();
            
            _currentSelectable = selectable;
            _commandButtonsView.Clear();

            if(selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _commandButtonsView.MakeLayout(commandExecutors);
            }
        }
    }
}
