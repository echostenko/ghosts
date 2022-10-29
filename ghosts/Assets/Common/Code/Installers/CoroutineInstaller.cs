using Common.Code.Services;
using Zenject;

namespace Common.Code.Installers
{
    public class CoroutineInstaller: MonoInstaller
    {
        public override void InstallBindings() => 
            BindCoroutineRunner();

        private void BindCoroutineRunner() => 
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
    }
}