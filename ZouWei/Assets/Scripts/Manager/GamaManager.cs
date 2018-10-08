using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Game
{
    public class GamaManager : SingletonMonobehaviour<GamaManager>
    {
        void Awake()
        {
            EventManager.Instance.Initialize();
            LevelManager.Instance.Initialize();
            PlayerManager.Instance.Initialize();
        }

        public void NextTurn()
        {
            PlayerManager.Instance.RefreshPlayerStatus();
        }
    }
}

