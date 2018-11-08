using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.Tilemaps;
using Game;

namespace BattleField
{
    public class ActionRequestMoveRange : Action
    {
        public ActionRequestMoveRange(Actor s, Actor t, EBattleActionType type) : base(s, t, type)
        {

        }

        public override void Execute()
        {
            var moveableTiles = source.GetMovableArea(EMap.BattleTerrainMap);
            BattleTerrainMap map = (BattleTerrainMap)BattleManager.Instance.tilemapDic[EMap.BattleTerrainMap];
            map.ShowActorCanReachTiles(moveableTiles);
        }
    }
}