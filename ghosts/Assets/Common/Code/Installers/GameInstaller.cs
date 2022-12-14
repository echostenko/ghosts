using Common.Code.Data;
using Common.Code.Ghost;
using Common.Code.Ghost.Interfaces;
using Common.Code.Input;
using Common.Code.Services;
using Common.Code.StateMachine;
using Common.Code.StateMachine.Factory;
using Common.Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Common.Code.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private StartButton startButton;
        [SerializeField] private GhostSettings ghostSettings;

        public override void InstallBindings()
        {
            BindStartButton();
            BindSceneService();
            BindStateFactory();
            BindStateMachine();
            BindInitializeState();
            BindGamePlayState();
            BindGhostFactory();
            BindGhostSpawner();
            BindGhostPool();
            BindGhostSettings();
        }

        private void BindGhostSettings() => 
            Container.Bind<GhostSettings>().FromScriptableObject(ghostSettings).AsSingle();
        
        private void BindGhostPool() => 
            Container.Bind<GhostPool>().AsSingle();

        private void BindGhostSpawner() => 
            Container.Bind<IGhostService>().To<GhostService>().AsSingle();

        private void BindGhostFactory() => 
            Container.Bind<IGhostFactory>().To<GhostFactory>().AsSingle();

        private void BindSceneService() => 
            Container.Bind<ScenesService>().AsSingle();

        private void BindStartButton() => 
            Container.Bind<IStartButton>().FromInstance(startButton);

        private void BindGamePlayState() =>
            Container.Bind<IState>().WithId("GamePlayState").To<GamePlayState>().AsSingle();

        private void BindInitializeState() =>
            Container.Bind<IState>().WithId("InitializeState").To<InitializeState>().AsSingle();

        private void BindStateMachine() =>
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

        private void BindStateFactory() =>
            Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
    }
}