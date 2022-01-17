using Abstractions.Commands;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserControl.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {
        public event Action<ICommandExecutor> CommandSelected;

        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _produceUnitButton;
        [SerializeField] private GameObject _stopButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Awake()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach(var currentExecutor in commandExecutors)
            {
                GameObject currentButtonObject = null;
                foreach(var currentButton in _buttonsByExecutorType)
                {
                    if(currentButton.Key.IsInstanceOfType(currentExecutor))
                    {
                        currentButtonObject = currentButton.Value;
                        break;
                    }
                }
                currentButtonObject.SetActive(true);
                var button = currentButtonObject.GetComponent<Button>();
                button.onClick.AddListener(() => CommandSelected?.Invoke(currentExecutor));
            }
        }

        public void BlockInteraction(ICommandExecutor executor)
        {
            UnblockAllInteractions();
            GetButtonObjectByType(executor.GetType()).GetComponent<Selectable>().interactable = false;
        }

        public void UnblockAllInteractions() => SetInteractable(true);

        public void Clear()
        {
            foreach(var currentExecutor in _buttonsByExecutorType)
            {
                currentExecutor.Value.SetActive(false);
                currentExecutor.Value.GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }

        private void SetInteractable(bool value)
        {
            _moveButton.GetComponent<Selectable>().interactable = value;
            _attackButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
        }

        private GameObject GetButtonObjectByType(Type executorType)
        {
            foreach(var currentButton in _buttonsByExecutorType)
            {
                if(currentButton.Key.IsAssignableFrom(executorType))
                    return currentButton.Value;
            }

            return null;
        }
    }
}
