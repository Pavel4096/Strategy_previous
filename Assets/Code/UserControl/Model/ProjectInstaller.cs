using Utils;
using Zenject;
using UnityEngine;

namespace UserControl.Model
{
    [CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Game/Project Installer")]
    public sealed class ProjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AssetsContext _assetsContext;
        [SerializeField] private Vector3Value _vector3Value;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_assetsContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        }
    }
}
