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
            PlayerManager.Instance.Initialize();
        }

        public void NextTurn()
        {
            PlayerManager.Instance.RefreshPlayerStatus();
        }
    }
}

