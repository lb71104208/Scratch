using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public enum EBattleTerrainTileType
    {
        PLAIN,
        GRASS,
        MOUNTAIN,
        WATER
    }

    [CreateAssetMenu]
    public class BattleTerrainTile : MyTile
    {
        public EBattleTerrainTileType tileType;

        public override int GetTileMoveConsume()
        {
            switch(tileType)
            {
                case EBattleTerrainTileType.GRASS:
                case EBattleTerrainTileType.PLAIN:
                    return 1;

                case EBattleTerrainTileType.MOUNTAIN:
                case EBattleTerrainTileType.WATER:
                    return -1;


                default:
                    return 1;
                    
            }
        }

    }
}


