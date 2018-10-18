﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class MyTile : TileBase
    {
        public Sprite tileSprite;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            tileData.sprite = tileSprite;
        }

        public virtual int GetTileMoveConsume()
        {
            return 1;
        }
    }
}

