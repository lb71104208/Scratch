using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleField
{
    public class BattleManager : Singleton<BattleManager>
    {
        public Actor actorPlayer;

        public void Initialize()
        {
            actorPlayer = GameObject.FindObjectOfType<Actor>();
        }
    }
}


