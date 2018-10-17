using BattleField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class Map : MonoBehaviour
    {
        public Tilemap tilemap;

        public MyTile _myTile;

        private void Start()
        {
            //_myTile = ScriptableObject.CreateInstance<MyTile>();
            //_myTile.tileSprite = sprite;
            //tilemap.SetTile(Vector3Int.zero, _myTile);

            //tilemap.RefreshAllTiles();
        }

        public void GetMovableTiles(Vector3Int startPoint, int range)
        {

        }

        public void ShowActorMovableTiles(Actor actor)
        {

        }

    }
}
