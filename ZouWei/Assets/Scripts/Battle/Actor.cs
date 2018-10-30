﻿using Common;
using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace BattleField
{
    public class Actor : MonoBehaviour
    {
        public const int moveRange = 5;
        protected ActorState _actorState;

        private List<Vector3Int> _movePath;
        private Vector3Int _destination;
        private Vector3Int _nextPosition;
        private int _currentMoveTargetIndex;

        private float _moveSpeed = 5.0f;
        private BattleTerrainMap _battleMap;

        // Use this for initialization

        private void GetMovableArea()
        {

        }

        public void BeginMove(List<Vector3Int> path)
        {
            _actorState = ActorState.Moving;
            _movePath = path;
            Vector3Int currentCellPos = GetActorTilePositionOnMap(EMap.BattleTerrainMap);
            if(currentCellPos == path[0])
            {
                _currentMoveTargetIndex = 1;
                _nextPosition = path[_currentMoveTargetIndex];
                _destination = path[path.Count - 1];
            }
        }

        private Vector3Int GetActorTilePositionOnMap(EMap mapType)
        {
            Tilemap map = BattleManager.Instance.tilemapDic[mapType].tilemap;
            Vector3Int cellPosition = map.WorldToCell(transform.position);
            return cellPosition;
        }

        private MyTile GetActorTileOnMap(EMap mapType)
        {
            Tilemap map = BattleManager.Instance.tilemapDic[mapType].tilemap;
            Vector3Int cellPosition = map.WorldToCell(transform.position);
            return map.GetTile<MyTile>(cellPosition);
        }

        private bool ReachTile(EMap mapType, Vector3Int cellPosition)
        {
            Tilemap map = BattleManager.Instance.tilemapDic[mapType].tilemap;
            Vector3 tileWorldPos = map.CellToWorld(cellPosition);
            Vector3 actorWorldPos = transform.position;
            return tileWorldPos == actorWorldPos;
        }

        private void Update()
        {
            MoveUpdate();
        }

        protected void MoveUpdate()
        {
            if(_actorState == ActorState.Moving)
            {
                if(ReachTile(EMap.BattleTerrainMap, _destination))
                {
                    _actorState = ActorState.Consumed;
                }
                else
                {
                    if(ReachTile(EMap.BattleTerrainMap, _nextPosition))
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
