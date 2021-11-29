using Abstractions.Commands;
using UnityEngine;

namespace Core.Commands
{
    public sealed class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand stopCommand)
        {
            Debug.Log("Stop command");
        }
    }
}
