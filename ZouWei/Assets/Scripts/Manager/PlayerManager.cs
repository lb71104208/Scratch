using UnityEngine;
using Common;

namespace Game
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        private Player.Player _player;

        public void Initialize()
        {
            _player = GameObject.FindObjectOfType<Player.Player>();
        }

        public void RefreshPlayerStatus()
        {
            _player.RestoreState();
        }

        public void OnEnterScene(int sceneIndex)
        {
            Debug.Log("sceneIndex " + sceneIndex);
            _player = GameObject.FindObjectOfType<Player.Player>();
            _player.OnEnterScene(sceneIndex);
        }
    }


}

