using Abstractions.Commands;
using UnityEngine;

namespace UserControl.Commands
{
    public sealed class PatrolCommand : IPatrolCommand
    {
        public Vector3 Position { get; }

        public PatrolCommand(Vector3 position)
        {
            Position = position;
        }
    }
}
