﻿using BattleField;
using Common;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class BattleTerrainMap : MyTilemap
    {
        private void Start()
        {
            BattleManager.Instance.RegistMap(EMap.BattleTerrainMap, this);
            Map.InitPathFindingMap(tilemap);
        }

        public void ShowActorCanReachTiles(Dictionary<Vector3Int, int> movableTiles)
        {
            foreach(Vector3Int point in movableTiles.Keys)
            {
                Tile tile = tilemap.GetTile<Tile>(point);
                if (tile != null)
                {
                    tilemap.SetColor(point, new Color(1f, 1f, 1f, 0.5f));
                }
            }
        }

        public void ShowPath(Vector3Int startPosition, Vector3Int destPosition)
        {
            
        }

        private void OnMouseOver()
        {
            //right click
            if (Input.GetMouseButtonUp(1))
            {
                Vector3Int cellPosition = MousePositionToCellPosition(Input.mousePosition);
                Vector3Int screenPosition = Utils.Vector3ToVector3Int(Input.mousePosition);
                screenPosition = screenPosition - new Vector3Int(Screen.width / 2, Screen.height / 2, 0);
                UIManager.Instance.ShowContextMenu(screenPosition, new BattleActorPlayerContext((ActorPlayer)BattleManager.Instance.actorPlayer));
            }

            //left click
            //if(Input.GetMouseButtonUp(0))
            //{
            //    Vector3Int cellPosition = MousePositionToCellPosition(Input.mousePosition);
            //    Vector3Int playerPosition = tilemap.WorldToCell(BattleManager.Instance.actorPlayer.transform.position);
            //    List<Vector3Int> path = Map.FindPath(tilemap, playerPosition, cellPosition);
            //    //List<Vector3Int> path = Map.FindPath(tilemap, cellPosition, Vector3Int.zero);
            //    BattleManager.Instance.actorPlayer.BeginMove(path);
            //    //foreach (Vector3Int cell in path)
            //    //{
            //    //    Tile tile = tilemap.GetTile<Tile>(cell);
            //    //    if (tile != null)
            //    //    {
            //    //        tilemap.SetColor(cell, new Color(0f, 1f, 0f, 0.5f));
            //    //    }
            //    //}
            //}
        }

        private Vector3Int MousePositionToCellPosition(Vector3 mousePosition)
        {
            mousePosition.z = 1.0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
            return cellPosition;
        }
    }
}


