using Abstractions;

namespace Abstractions.Commands
{
    public interface IAttackCommand : ICommand
    {
        IAttackable Attackable { get; }
    }
}
