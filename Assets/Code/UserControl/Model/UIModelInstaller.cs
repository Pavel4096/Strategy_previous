using Abstractions.Commands;
using Utils;
using Zenject;
using UnityEngine;

namespace UserControl.Model
{
    public sealed class UIModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsSingle();
        }
    }
}
