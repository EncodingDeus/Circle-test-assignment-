namespace Circle
{
    public class PlayerController
    {
        private readonly IPlayerView _playerView;
        private IGameManager _manager;
        private IInput _input;


        public PlayerController(IPlayerView playerView)
        {
            _playerView = playerView;
        }

        public void Initialize(IGameManager manager, IInput input)
        {
            _input = input;
            _manager = manager;

            _manager.OnRun += OnUpdatePosition;
        }

        private void OnUpdatePosition()
        {
            _playerView.SetPosition(_input.GetCursorPosition());
        }
    }
}
