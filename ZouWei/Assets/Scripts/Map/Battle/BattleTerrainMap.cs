using BattleField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class BattleTerrainMap : MyTilemap
    {
        private void Start()
        {
            ShowActorCanReachTiles(null);
        }

        public void ShowActorCanReachTiles(Actor actor)
        {
            //Vector3 position = actor.transform.position;
            //Vector3Int cellPosition = tilemap.WorldToCell(position);
            //tilemap.SetTile(cellPosition, _myTile);

            Vector3Int cellPosition = new Vector3Int(0, 0, 0);

            int range = 1;
            Dictionary<Vector3Int, int> movableTiles = new Dictionary<Vector3Int, int>();
            movableTiles.Add(cellPosition, range);
            Map.GetMovableTiles(tilemap, cellPosition, range, ref movableTiles);

            foreach(Vector3Int point in movableTiles.Keys)
            {
                Tile tile = tilemap.GetTile<Tile>(cellPosition);
                if (tile != null)
                {
                    tilemap.SetColor(point, new Color(1f, 1f, 1f, 0.5f));
                }
            }
        }
    }
}


