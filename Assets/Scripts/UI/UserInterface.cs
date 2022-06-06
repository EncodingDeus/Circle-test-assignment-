using UnityEngine;

namespace Circle
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private IdlePanel idlePanel;
        [SerializeField] private FinishPanel finishPanel;

        private IGameManager _gameManager;

        public void Initialize(IGameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.OnFinish += OnFinishGame;
        }

        public void StartGame()
        {
            _gameManager.StartGame();
            idlePanel.Hide();
            finishPanel.Hide();
        }

        public void RestartGame()
        {
            _gameManager.RestartGame();
            idlePanel.Show();
            finishPanel.Hide();
        }

        public void OnFinishGame()
        {
            idlePanel.Hide();
            finishPanel.Show();
        }
    }
}
