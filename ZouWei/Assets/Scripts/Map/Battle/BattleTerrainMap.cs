using BattleField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class BattleTerrainMap : MyTilemap
    {


        public void ShowActorMovableTiles(Actor actor)
        {
            Vector3 position = actor.transform.position;
            Vector3Int cellPosition = tilemap.WorldToCell(position);
            //tilemap.SetTile(cellPosition, _myTile);
        }
    }
}


