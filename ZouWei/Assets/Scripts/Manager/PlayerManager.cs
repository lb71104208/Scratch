using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Common;
using Game;

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
    }


}

