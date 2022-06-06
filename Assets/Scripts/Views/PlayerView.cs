using UnityEngine;

namespace Circle
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private SpriteRenderer playerArea;
        [SerializeField] private float _radius = 0.1f;

        private PlayerController _playerController;

        public float Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                playerArea.transform.localScale = Vector3.one * _radius * 2;
            }
        }

        private void Awake()
        {
            _playerController = new PlayerController(this);
        }

        public void Initialize(IGameManager manager, IInput input)
        {
            _playerController.Initialize(manager, input);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}
