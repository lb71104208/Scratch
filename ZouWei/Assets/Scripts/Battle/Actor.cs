using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleField
{
    public class Actor : MonoBehaviour
    {
        public enum ActorState
        {
            Active,
            Moving,
            Attacking,
            Consumed
        }
        public const int moveRange = 5;
        protected ActorState _actorState;

        private List<Vector3Int> _movePath;
        private Vector3Int _destination;

        // Use this for initialization

        private void GetMovableArea()
        {

        }

        public void BeginMove(List<Vector3Int> path)
        {
            _actorState = ActorState.Moving;
        }

        private void Update()
        {

        }
    }
}
