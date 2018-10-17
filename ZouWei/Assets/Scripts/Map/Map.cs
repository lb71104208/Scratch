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

        private Actor _actor;

        private void Start()
        {
            _actor = FindObjectOfType<Actor>();
            ShowActorMovableTiles(_actor);
        }

        public void GetMovableTiles(Vector3Int startPoint, int range, ref List<Vector3Int> tilePositions)
        {
            tilePositions.Add(startPoint);
            range--;
        }

        public void ShowActorMovableTiles(Actor actor)
        {
            Vector3 position = actor.transform.position;
            Vector3Int cellPosition = tilemap.WorldToCell(position);
            tilemap.SetTile(cellPosition, _myTile);
        }

    }
}
