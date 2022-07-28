using System.Collections.Generic;
using UnityEngine;

namespace SuperBall
{
    public class PlayerControll : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private Player _playerPrefab;
        private float _startTickTime;
        private Player _player;
        private List<Player> _clonesPlayers = new List<Player>();

        private void Start()
        {
            _player = InstantiatePlayer("Player");
            _player.Initialization(new CreatesPath(_minSpeed, _maxSpeed));

            _startTickTime = -1;
        }

        private Player InstantiatePlayer(string namePlayer)
        {
            Player player = GameObject.Instantiate(_playerPrefab, transform);
            player.name = namePlayer;
            return player;
        }

        private void Update()
        {
            if (Time.time - _startTickTime > 1)
            {
                _player.NextTick();
                for (int i = 0; i < _clonesPlayers.Count; i++)
                {
                    _clonesPlayers[i].NextTick();
                }
                _startTickTime = Time.time;
            }
            _player.UpdateState(Time.time - _startTickTime);
            for (int i = 0; i < _clonesPlayers.Count; i++)
            {
                _clonesPlayers[i].UpdateState(Time.time - _startTickTime);
            }

            if (Input.GetKeyUp(KeyCode.R) && _player.Path.GetPathLog().Count > 0)
            {
                Player clonePlayer = InstantiatePlayer("ClonePlayer");

                clonePlayer.Initialization(new FollowPath(_player.Path.GetPathLog(), Time.time - _startTickTime));
                clonePlayer.CopyAbilityData(_player.ability);
                _clonesPlayers.Add(clonePlayer);

                _player.Initialization(new CreatesPath(_minSpeed, _maxSpeed));
            }
        }
    }
}