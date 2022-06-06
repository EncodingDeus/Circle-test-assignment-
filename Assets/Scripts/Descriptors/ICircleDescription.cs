using UnityEngine;

namespace Circle
{
    public interface ICircleDescription
    {
        public Vector2 StartPosition { get; }
        public Vector2 FinishPosition { get; }

        public float Speed { get; set; }
        public float Acceleration { get; set; }

    }
}
