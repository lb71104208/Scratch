using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class MyTile : Tile
    { 
        public Sprite replaceSprite;

        public virtual int GetTileMoveConsume()
        {
            return 1;
        }
    }
}

