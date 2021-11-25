using UnityEngine;

namespace Abstractions.Commands
{
    public interface IMoveCommand : ICommand
    {
        Vector3 MovePosition { get; }
    }
}
