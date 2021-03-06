﻿using Astar;
using BattleField;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game
{
    public class Map
    {
        public static void InitPathFindingMap(Tilemap tilemap)
        {
            PathFinding.map = new Dictionary<Vector3Int, Node>();
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                MyTile tile = tilemap.GetTile<MyTile>(position);
                Node node = new Node(position, tile.GetTileMoveConsume());
                PathFinding.map.Add(position, node);
            }
        }

        public static void GetCanReachTiles(Tilemap tilemap, Vector3Int startPoint, int range, ref Dictionary<Vector3Int, int> tilePositions)
        {
            List<Vector3Int> nextPoints = GetNextWalkableTiles(tilemap, startPoint);
            foreach(Vector3Int point in nextPoints)
            {
                int cost = tilemap.GetTile<MyTile>(point).GetTileMoveConsume();
                if (cost <= range)
                {
                    int rangeLeft = range - cost;
                    if(!tilePositions.ContainsKey(point))
                    {
                        tilePositions.Add(point, rangeLeft);
                    }
                    else
                    {
                        if(rangeLeft > tilePositions[point])
                        {
                            tilePositions[point] = rangeLeft;
                        }
                    }

                    GetCanReachTiles(tilemap, point, rangeLeft, ref tilePositions);
                }      
            }
        }

        public static List<Vector3Int> FindPath(Tilemap tilemap, Vector3Int startPoint, Vector3Int destPoint)
        {            
            List<Node> pathNode = PathFinding.A_Star(PathFinding.map[startPoint], PathFinding.map[destPoint]);
            List<Vector3Int> pathPos = new List<Vector3Int>();
            foreach (Node node in pathNode)
            {
                pathPos.Add(node.Position);
            }
            return pathPos;
        }

        private static List<Vector3Int> GetNextWalkableTiles(Tilemap tilemap, Vector3Int point)
        {
            List<Vector3Int> ret = new List<Vector3Int>();

            Vector3Int leftPoint = point + Vector3Int.left;
            MyTile tile = tilemap.GetTile<MyTile>(leftPoint);
            if(tile != null && tile.GetTileMoveConsume() >= 0)
            {
                ret.Add(leftPoint);
            }

            Vector3Int rightPoint = point + Vector3Int.right;
            tile = tilemap.GetTile<MyTile>(rightPoint);
            if (tile != null && tile.GetTileMoveConsume() >= 0)
            {
                ret.Add(rightPoint);
            }

            Vector3Int upPoint = point + Vector3Int.up;
            tile = tilemap.GetTile<MyTile>(upPoint);
            if (tile != null && tile.GetTileMoveConsume() >= 0)
            {
                ret.Add(upPoint);
            }

            Vector3Int downPoint = point + Vector3Int.down;
            tile = tilemap.GetTile<MyTile>(downPoint);
            if (tile != null && tile.GetTileMoveConsume() >= 0)
            {
                ret.Add(downPoint);
            }

            return ret;
        }

    }
}
