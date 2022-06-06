using UnityEngine;

namespace Circle
{
    public interface IPlayerView
    {
        public float Radius { get; set; }
        public void SetPosition(Vector3 position);
        public void Initialize(IGameManager manager, IInput input);
        public Vector3 GetPosition();
    }
}
