using UnityEngine;

namespace Circle
{
    public class Input : IInput
    {
        private readonly Camera _camera;

        public Input(Camera camera)
        {
            _camera = camera;
        }

        public Vector2 GetCursorPosition()
        {
            return _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        }
    }
}
