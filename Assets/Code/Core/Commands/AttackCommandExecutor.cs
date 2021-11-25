using Abstractions.Commands;
using UnityEngine;

namespace Core.Commands
{
    public sealed class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand attackCommand)
        {
            Debug.Log("Attack command");
        }
    }
}
