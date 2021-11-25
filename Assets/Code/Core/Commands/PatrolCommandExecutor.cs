using Abstractions.Commands;
using UnityEngine;

namespace Core.Commands
{
    public sealed class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand patrolCommand)
        {
            Debug.Log("Patrol command");
        }
    }
}
