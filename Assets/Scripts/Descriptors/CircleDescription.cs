using System;
using UnityEngine;

namespace Circle
{
    [Serializable]
    public class CircleDescription : ICircleDescription
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform finishPoint;
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float acceleration = 1.0f;

        public Vector2 StartPosition => startPoint.position;
        public Vector2 FinishPosition => finishPoint.position;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public float Acceleration
        {
            get => acceleration;
            set => acceleration = value;
        }
    }
}
