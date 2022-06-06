using UnityEngine;

namespace Circle
{
    public interface ICircleView
    {
        public float Radius { get; }
        public Vector2 GetPosition();
        public void Reset();
        public void MoveForward();
        public void MoveBackward();

        /// <summary>
        /// Changing relative position
        /// </summary>
        public void Move(float pos);
    }
}