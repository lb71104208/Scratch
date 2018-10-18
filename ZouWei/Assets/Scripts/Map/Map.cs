using BattleField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class Map
    {
        public void GetMovableTiles(Tilemap tilemap, Vector3Int startPoint, int range, ref List<Vector3Int> tilePositions)
        {
            tilePositions.Add(startPoint);
            if(range <=0)
            {
                return;
            }

            MyTile tile = tilemap.GetTile<MyTile>(startPoint);
            int consume = tile.GetTileMoveConsume();


        }



    }
}
