using UnityEngine;

namespace Circle
{
    public class CircleController
    {
        private readonly ICircleView _circleView;
        private readonly ICircleDescription _description;
        private IGameManager _manager;
        private IPlayerView _player;

        public CircleController(ICircleView circleView, ICircleDescription description)
        {
            _circleView = circleView;
            _description = description;
        }

        public void Initialize(IGameManager manager, IPlayerView player)
        {
            _player = player;
            _manager = manager;

            _manager.OnStart += OnStartGame;
            _manager.OnRun += OnUpdatePosition;
        }

        private void OnStartGame()
        {
            _circleView.Reset();
        }

        private void OnUpdatePosition()
        {
            // Handle Move to finish
            if (Vector2.Distance(_circleView.GetPosition(), _description.FinishPosition) > _circleView.Radius)
            {
                // Handle player
                if (Vector3.Distance(_player.GetPosition(),
                _circleView.GetPosition()) > _player.Radius + _circleView.Radius)
                {
                    _circleView.MoveForward();
                }
                else if (Vector2.Distance(_circleView.GetPosition(), _description.StartPosition) > _circleView.Radius)
                {
                    _circleView.MoveBackward();
                }
            }
            else
            {
                _manager.FinishGame();
            }
        }
    }
}
