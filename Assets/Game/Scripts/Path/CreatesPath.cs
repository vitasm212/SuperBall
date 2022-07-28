using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public class CreatesPath : IPath
    {
        private PathLogger _pathLoger;
        public PathLogger PathLoger { get { return _pathLoger; } }

        private float _minSpeed;
        private float _maxSpeed;

        public CreatesPath(float minSpeed, float maxSpeed)
        {
            _pathLoger = new PathLogger();
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
        }

        public Vector3 GetNewDirection()
        {
            Vector3 direction = Random.insideUnitCircle * Random.Range(_minSpeed, _maxSpeed);
            direction.z = direction.y;
            direction.y = 0;
            _pathLoger.Add(direction);
            return direction;
        }

        public List<Vector3> GetPathLog()
        {
            return _pathLoger.Direction;
        }

        public float MaxTickProgress()
        {
            return 1;
        }

        public bool IsEndPath()
        {
            return false;
        }
    }
}