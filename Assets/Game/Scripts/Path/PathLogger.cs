using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public class PathLogger
    {
        private List<Vector3> _direction = new List<Vector3>();
        public List<Vector3> Direction { get { return _direction; } }

        public void Add(Vector3 direction)
        {
            _direction.Add(direction);
        }
    }
}