using UnityEngine;

namespace SuperBall
{
    public class SpeedControlAbility : Ability
    {
        [SerializeField] private float _speedExecute;
        public override void Execute()
        {
            if (_playerStats.Speed() > _speedExecute)
            {
                _playerMaterial.color = Color.green;
            }
        }
    }
}