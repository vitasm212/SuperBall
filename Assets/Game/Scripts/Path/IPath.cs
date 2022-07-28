using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public interface IPath
    {
        public Vector3 GetNewDirection();
        public List<Vector3> GetPathLog();
        public float MaxTickProgress();
        public bool IsEndPath();
    }
}
