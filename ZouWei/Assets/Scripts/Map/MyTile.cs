using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class MyTile : Tile
    { 
        public Sprite replaceSprite;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            //base.GetTileData(position, tilemap, ref tileData);
            tileData.sprite = sprite;
            if (position == Vector3Int.zero)
            {
                tileData.color = Color.red;
            }
        }

        public virtual int GetTileMoveConsume()
        {
            return 1;
        }
    }
}

