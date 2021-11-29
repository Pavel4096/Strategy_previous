using Abstractions;
using Abstractions.Commands;

namespace UserControl.Commands
{
    public sealed class AttackCommand : IAttackCommand
    {
        public IAttackable Attackable { get; }

        public AttackCommand(IAttackable attackable) => Attackable = attackable;
    }
}
