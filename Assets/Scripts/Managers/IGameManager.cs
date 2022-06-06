using System;

namespace Circle
{
    public interface IGameManager
    {
        public event Action OnStart;
        public event Action OnRun;
        public event Action OnRestart;
        public event Action OnFinish;

        public GameState State { get; }

        public void StartGame();
        public void RestartGame();
        public void FinishGame();
    }
}
