using Abstractions.Commands;
using UnityEngine;

namespace Core.Commands
{
    public sealed class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand moveCommand)
        {
            Debug.Log(moveCommand.MovePosition);
        }
    }
}
