using Common.Code.Input;
using Common.Code.StateMachine;
using Common.Code.StateMachine.States;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Code.Services
{
    public class ScenesService
    {
        private readonly IStartButton startButton;
        private readonly IGameStateMachine gameStateMachine;
        private const string ghostsSceneName = "GhostsScene";

        [Inject]
        public ScenesService(IStartButton startButton, IGameStateMachine gameStateMachine)
        {
            this.startButton = startButton;
            this.gameStateMachine = gameStateMachine;
        }

        public void Initialize() => 
            startButton.OnStartButtonClicked += StartButtonOnOnStartButtonClicked;

        private void StartButtonOnOnStartButtonClicked()
        {
            startButton.OnStartButtonClicked -= StartButtonOnOnStartButtonClicked;

            SceneManager.LoadScene(ghostsSceneName);
            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
            
        }

        private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;
            gameStateMachine.Enter<GamePlayState>();
        }
    }
}