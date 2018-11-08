using Common;
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
        private float _moveTimer;

        private CharacterMotion _actorMotion;

        private void Awake()
        {
            _actorMotion = GetComponent<CharacterMotion>();
        }

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
                Vector3 nextDirection = _movePath[1] - _movePath[0];
                _actorMotion.MoveDirection(nextDirection.x, nextDirection.y);

                _currentMoveTargetIndex = 1;
                _nextPosition = path[_currentMoveTargetIndex];
                _destination = path[path.Count - 1];
                _moveTimer = 0;
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
            Vector3 tileWorldPos = map.CellToWorld(cellPosition) + map.cellSize/2;
            Vector3 actorWorldPos = transform.position;
            if(tileWorldPos == actorWorldPos)
            {
                transform.position = tileWorldPos;
                return true;
            }
            else
            {
                return false;
            }
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
                    OnReachDestination();
                }
                else
                {
                    if(ReachTile(EMap.BattleTerrainMap, _nextPosition))
                    {
                        Vector3 nextDirection = _movePath[_currentMoveTargetIndex + 1] - _movePath[_currentMoveTargetIndex];
                        _actorMotion.MoveDirection(nextDirection.x, nextDirection.y);

                        MoveToNextPoint();
                    }
                    else
                    {
                        MoveToTile(EMap.BattleTerrainMap, _nextPosition);
                    }
                }
            }
        }

        private void OnReachDestination()
        {
            _actorMotion.Stop();
            _actorState = ActorState.Consumed;
        }

        private void MoveToNextPoint()
        {
            _currentMoveTargetIndex++;
            _nextPosition = _movePath[_currentMoveTargetIndex];
            _moveTimer = 0;
            MoveToTile(EMap.BattleTerrainMap, _nextPosition);
        }

        private void MoveToTile(EMap mapType, Vector3Int tilePos)
        {
            Tilemap map = BattleManager.Instance.tilemapDic[mapType].tilemap;
            Vector3 tileWorldPos = map.CellToWorld(tilePos)+map.cellSize/2;
            Vector3 actorWorldPos = transform.position;
            _moveTimer += Time.deltaTime * _moveSpeed;

            transform.position = Vector3.Lerp(actorWorldPos, tileWorldPos, _moveTimer);
        }
    }
}
