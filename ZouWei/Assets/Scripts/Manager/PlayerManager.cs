using UnityEngine;
using Common;
using MainPlayer;

namespace Game
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        private Player _player;

        public Player MainPlayer { get { return _player; } }

        public void Initialize()
        {
            _player = GameObject.FindObjectOfType<Player>();
        }

        public void RefreshPlayerStatus()
        {
            _player.RestoreState();
        }

        public void OnEnterScene(int sceneIndex)
        {
            _player = GameObject.FindObjectOfType<Player>();
            if(_player != null)
            {
                _player.OnEnterScene(sceneIndex);
            }
            
        }
    }


}

