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
        public Vector2Int Position;
        public float F; // F = G + H
        public float G; // Total cost from the beginning
        public float H; // Heuristic cost of remaining path to goal

        public Node(Vector2Int pos)
        {
            Position = pos;
        }
    }
}
