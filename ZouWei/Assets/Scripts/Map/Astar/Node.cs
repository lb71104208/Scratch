//----------------------------------------------
// File: Node.cs
// Copyright © 2018 InsertCoin (www.insertcoin.info)
// Author: Omer Akyol
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace Astar
{
    public class Node
    {
        public Node Parent;
        public Vector3Int Position;
        public int F; // F = G + H
        public int G; // Total cost from the beginning
        public int H; // Heuristic cost of remaining path to goal
        public int moveCost;

        public Node(Vector3Int pos, int move_cost)
        {
            Position = pos;
            moveCost = move_cost;
        }
    }
}
