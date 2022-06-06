using System;
using UnityEngine;

namespace Circle
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private CircleView circleView;
        [SerializeField] private UserInterface userInterface;

        private IInput _input;
        private GameState _state;

        public GameState State
        {
            get => _state;
            private set => _state = value;
        }

        public event Action OnStart;
        public event Action OnRun;
        public event Action OnRestart;
        public event Action OnFinish;


        private void Awake()
        {
            _input = new Input(mainCamera);
            playerView.Initialize(this, _input);
            circleView.Initialize(this, playerView);
            userInterface.Initialize(this);
        }

        private void FixedUpdate()
        {
            if (State == GameState.Start)
            {
                OnRun?.Invoke();
            }
        }

        public void StartGame()
        {
            State = GameState.Start;
            OnStart?.Invoke();
        }

        public void RestartGame()
        {
            State = GameState.Idle;
            OnRestart?.Invoke();
        }

        public void FinishGame()
        {
            State = GameState.Finish;
            OnFinish?.Invoke();
        }
    }
}
