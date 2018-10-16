using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class Map : MonoBehaviour
    {
        Tilemap tilemapTerrain;

        private void Awake()
        {
            tilemapTerrain = GetComponent<Tilemap>();
        }

        private void Start()
        {
            Tile tile = tilemapTerrain.GetTile<Tile>(Vector3Int.zero);
            TileData tileData;
            //tile.GetTileData(Vector3Int.zero, tilemapTerrain, ref tileData);

            tilemapTerrain.RefreshAllTiles();
        }

    }
}
