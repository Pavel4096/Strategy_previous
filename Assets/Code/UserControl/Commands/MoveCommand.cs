using Abstractions.Commands;
using UnityEngine;

namespace UserControl.Commands
{
    public sealed class MoveCommand : IMoveCommand
    {
        public Vector3 MovePosition => _movePosition;
        private Vector3 _movePosition;

        public MoveCommand(Vector3 movePosition)
        {
            _movePosition = movePosition;
        }
    }
}
