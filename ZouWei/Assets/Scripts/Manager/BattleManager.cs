using Common;
using Game;
using System.Collections.Generic;
using UnityEngine;

namespace BattleField
{
    public class BattleManager : Singleton<BattleManager>
    {
        public Actor actorPlayer;
        public Dictionary<EMap, MyTilemap> tilemapDic;

        public void Initialize()
        {
            actorPlayer = GameObject.FindObjectOfType<Actor>();
            tilemapDic = new Dictionary<EMap, MyTilemap>();
        }

        public void RegistMap(EMap mapType, MyTilemap map)
        {
            if(tilemapDic.ContainsKey(mapType))
            {
                tilemapDic[mapType] = map;
            }
            else
            {
                tilemapDic.Add(mapType, map);
            }
        }
    }
}


