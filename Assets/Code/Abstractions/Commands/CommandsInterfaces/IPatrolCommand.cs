using UnityEngine;

namespace Abstractions.Commands
{
    public interface IPatrolCommand : ICommand
    {
        Vector3 Position { get; }
    }
}
