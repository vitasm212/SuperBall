using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public class DistanceControlAbility : Ability
    {
        [SerializeField] private float _mileageExecute;
        private List<Color> colors;
        private float _mileage;
        private int _indexColor;

        public override void CopyData(Ability ability)
        {
            if (ability is DistanceControlAbility distanceControlAbility)
            {
                colors.AddRange(distanceControlAbility.colors.ToArray());
            }
            base.CopyData(ability);
        }

        public override void Initialization(PlayerStats playerStats, Material playerMaterial)
        {
            _indexColor = -1;
            _mileage = 0;
            colors = new List<Color>();

            base.Initialization(playerStats, playerMaterial);
        }

        public override void Execute()
        {
            if (_playerStats.Mileage() - _mileage > _mileageExecute)
            {
                _indexColor++;
                if (colors.Count <= _indexColor)
                {
                    colors.Add(new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));
                }
                _mileage = _playerStats.Mileage();
                _playerMaterial.color = colors[_indexColor];
            }
        }
    }
}