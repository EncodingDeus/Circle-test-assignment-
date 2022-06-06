using UnityEngine;

namespace Circle
{
    public class CircleView : MonoBehaviour, ICircleView
    {
        [SerializeField] private CircleDescription circleDescription;
        [SerializeField] private float radius = 0.5f;

        private float _acceleration = 0;
        private CircleController _circleController;

        public float Radius => radius;


        private void Awake()
        {
            _circleController = new CircleController(this, circleDescription);
        }

        public void Initialize(IGameManager manager, IPlayerView player)
        {
            _circleController.Initialize(manager, player);
        }

        public void MoveBackward()
        {
            Move(-1);
        }

        public void MoveForward()
        {
            Move(1);
        }

        public void Move(float targetSpeed)
        {
            _acceleration = Mathf.Clamp(_acceleration + (targetSpeed * circleDescription.Acceleration),
                -circleDescription.Speed, circleDescription.Speed);
            Vector3 targetDirection = (circleDescription.FinishPosition - circleDescription.StartPosition).normalized;
            transform.position += (targetDirection * _acceleration) * Time.fixedDeltaTime;
        }

        private void SetInitialPosition()
        {
            transform.position = circleDescription.StartPosition;
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public void SetAcceleration(float acceleration)
        {
            circleDescription.Acceleration = acceleration;
        }

        public new void Reset()
        {
            SetInitialPosition();
            _acceleration = 0;
        }
    }
}