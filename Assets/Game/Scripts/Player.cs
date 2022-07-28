using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public List<Ability> ability;
        [SerializeField] private Renderer _renderer;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private PlayerStats _playerStats;
        private IPath _path;
        public IPath Path { get { return _path; } }

        public void Initialization(IPath path)
        {
            _path = path;
            _renderer.material.color = Color.white;            
            _startPosition = new Vector3(0, 0, 0);
            _endPosition = new Vector3(0, 0, 0);
            _playerStats = new PlayerStats();
            transform.position = new Vector3(0, 0, 0);
            InitializationAbility();
        }

        public void NextTick()
        {
            Vector3 newDirection = _path.GetNewDirection();

            _playerStats.SetSpeed(newDirection.magnitude);
            _playerStats.AddLockMileage((_startPosition - _endPosition).magnitude);

            SetTickTarget(newDirection);
        }

        public void CopyAbilityData(List<Ability> abilityToCopy)
        {
            for (int i = 0; i < ability.Count; i++)
            {
                ability[i].CopyData(abilityToCopy[i]);
            }
        }

        public void InitializationAbility()
        {
            if (ability != null)
            {
                for (int i = 0; i < ability.Count; i++)
                {
                    ability[i].Initialization(_playerStats, _renderer.material);
                }
            }
        }

        public void UpdateState(float progress)
        {
            if (!_path.IsEndPath())
            {
                if (progress > _path.MaxTickProgress())
                {
                    progress = _path.MaxTickProgress();
                }
                transform.position = Vector3.Lerp(_startPosition, _endPosition, progress);

                _playerStats.TickMileage(((_endPosition - _startPosition) * progress).magnitude);

                ExecuteAbility();
            }
        }

        private void ExecuteAbility()
        {
            if (ability != null)
            {
                for (int i = 0; i < ability.Count; i++)
                {
                    ability[i].Execute();
                }
            }
        }

        public void SetTickTarget(Vector3 newDirection)
        {
            _startPosition = _endPosition;
            _endPosition += newDirection;
        }
    }
}