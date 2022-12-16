using OpenTK.Mathematics;
using System;

namespace OpenTK_Cubo_Phong
{
    public class Camera
    {
        private Vector3 _front = -Vector3.UnitZ;
        private Vector3 _up = Vector3.UnitY;
        private Vector3 _right = Vector3.UnitX;
        private Vector3 _at = new Vector3(0,0,0);
        private float _pitch;
        private float _yaw = -MathHelper.PiOver2; // Without this, you would be started rotated 90 degrees right.
        private float _fov = MathHelper.PiOver2;
        private float _velocity;

        public Camera(Vector3 position, float aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;
            Velocity = 4;
        }

        public Vector3 Position { get; set; }
        public float AspectRatio { private get; set; }
        public Vector3 Front => _front;
        public Vector3 Up => _up;
        public Vector3 Right => _right;

        public float Velocity
        {
            get{ return this._velocity; }
            set{ this._velocity = value; }
        }

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(_pitch);
            set
            {
                var angle = MathHelper.Clamp(value, -89f, 89f);
                _pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(_yaw);
            set
            {
                _yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, this._at, _up);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.01f, 100f);
        }

        private void UpdateVectors()
        {
            _front = Vector3.Normalize(Vector3.Add(this._at, -Position));
            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up    = Vector3.Normalize(Vector3.Cross(_right, _front));
        }
    }
}