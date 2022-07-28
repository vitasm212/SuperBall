using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public class FollowPath : IPath
    {
        private int _tickIndex;
        private List<Vector3> _path;
        private float _lastTickProgress;

        public FollowPath(List<Vector3> path, float lastTickProgress)
        {
            _tickIndex = -1;
            _path = path;
            _lastTickProgress = lastTickProgress;
        }

        public Vector3 GetNewDirection()
        {
            _tickIndex++;
            if (_tickIndex < _path.Count)
            {
                return _path[_tickIndex];
            }
            else
            {
                return _path[_path.Count - 1];
            }
        }

        public List<Vector3> GetPathLog()
        {
            return null;
        }

        public bool IsEndPath()
        {
            return _tickIndex >= _path.Count;
        }

        public float MaxTickProgress()
        {
            if (_tickIndex < _path.Count - 1)
            {
                return 1;
            }
            else
            {
                return _lastTickProgress;
            }
        }

    }
}