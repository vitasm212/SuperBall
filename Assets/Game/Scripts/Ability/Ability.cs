using System;
using UnityEngine;

namespace SuperBall
{
    public abstract class Ability : MonoBehaviour
    {
        protected Material _playerMaterial;
        protected PlayerStats _playerStats;
        public abstract void Execute();
        public virtual void CopyData(Ability ability) { }
        public virtual void Initialization(PlayerStats playerStats, Material playerMaterial)
        {
            _playerStats = playerStats;
            _playerMaterial = playerMaterial;
        }
    }
}