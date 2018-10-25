using System.Collections.Generic;
using UnityEngine;
using Algorithms;

namespace Astar
{
    public class PathFinding
    {
        public static Dictionary<Vector3Int, Node> map;
        private static Dictionary<Node, Node> _cameFrom;

        private static List<Node> ConstructPath(Dictionary<Node, Node> cameFrom, Node dest)
        {
            List<Node> path = new List<Node>();
            if (dest != null)
            {
                path.Add(dest);
            }
            while (cameFrom.ContainsKey(dest))
            {
                dest = cameFrom[dest];
                path.Add(dest);
            }
            path.Reverse();
            return path;
        }

        public static List<Node> A_Star(Node start, Node dest)
        {
            List<Node> closedSet = new List<Node>();
            PriorityQueue<Node> openSet = new PriorityQueue<Node>(new SortNodeByFCost());
          
            _cameFrom = new Dictionary<Node, Node>();

            start.G = 0;
            start.F = HeuristicCostEstimate(start, dest);

            openSet.Push(start);

            while (openSet.Count > 0)
            {
                Node current = openSet.Pop();
                if (current == dest)
                {
                    return ConstructPath(_cameFrom, current);
                }

                openSet.RemoveLocation(current);
                closedSet.Add(current);

                List<Node> neighbourNodes = GetNeighbourNode(current);

                foreach(Node neighbourNode in neighbourNodes)
                {
                    if(closedSet.Contains(neighbourNode))
                    {
                        continue;
                    }

                    int tentativeG = current.G + neighbourNode.moveCost;
                    if(!(openSet.Contains(neighbourNode)))
                    {
                        neighbourNode.G = tentativeG;
                        neighbourNode.F = neighbourNode.G + HeuristicCostEstimate(neighbourNode, dest);
                        openSet.Push(neighbourNode);
                    }
                    else if(tentativeG >= neighbourNode.G)
                    {
                        continue;
                    }

                    _cameFrom[neighbourNode] = current;
                    neighbourNode.G = tentativeG;
                    neighbourNode.F = neighbourNode.G + HeuristicCostEstimate(neighbourNode, dest);
                }
            }

            return ConstructPath(null, null);
        }

        private static List<Node> GetNeighbourNode(Node node)
        {
            List<Node> ret = new List<Node>();

            Vector3Int leftPosition = node.Position + Vector3Int.left;
            if (map.ContainsKey(leftPosition))
            {
                Node leftNode = map[leftPosition];
                if(leftNode.moveCost > 0)
                {
                    ret.Add(leftNode);
                }
            }

            Vector3Int rightPosition = node.Position + Vector3Int.right;
            if (map.ContainsKey(rightPosition))
            {
                Node rightNode = map[rightPosition];
                if (rightNode.moveCost > 0)
                {
                    ret.Add(rightNode);
                }
            }

            Vector3Int upPosition = node.Position + Vector3Int.up;
            if (map.ContainsKey(upPosition))
            {
                Node upNode = map[upPosition];
                if (upNode.moveCost > 0)
                {
                    ret.Add(upNode);
                }
            }

            Vector3Int downPosition = node.Position + Vector3Int.down;
            if (map.ContainsKey(downPosition))
            {
                Node downNode = map[downPosition];
                if (downNode.moveCost > 0)
                {
                    ret.Add(downNode);
                }
            }

            return ret;
        }

        private static int HeuristicCostEstimate(Node a, Node b)
        {
            int cntX = Mathf.Abs(a.Position.x - b.Position.x);
            int cntY = Mathf.Abs(a.Position.y - b.Position.y);

            return cntX + cntY;
        }

        private class SortNodeByFCost : IComparer<Node>
        {
            public int Compare(Node A, Node B)
            {
                if (A.F < B.F)
                {
                    return -1;
                }
                else if (A.F == B.F)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

            }

        }

        /*
         function reconstruct_path(cameFrom, current)
        total_path := {current}
        while current in cameFrom.Keys:
            current := cameFrom[current]
            total_path.append(current)
        return total_path

    function A_Star(start, goal)
        // The set of nodes already evaluated
        closedSet := {}

        // The set of currently discovered nodes that are not evaluated yet.
        // Initially, only the start node is known.
        openSet := {start}

        // For each node, which node it can most efficiently be reached from.
        // If a node can be reached from many nodes, cameFrom will eventually contain the
        // most efficient previous step.
        cameFrom := an empty map

        // For each node, the cost of getting from the start node to that node.
        gScore := map with default value of Infinity

        // The cost of going from start to start is zero.
        gScore[start] := 0

        // For each node, the total cost of getting from the start node to the goal
        // by passing by that node. That value is partly known, partly heuristic.
        fScore := map with default value of Infinity

        // For the first node, that value is completely heuristic.
        fScore[start] := heuristic_cost_estimate(start, goal)

        while openSet is not empty
            current := the node in openSet having the lowest fScore[] value
            if current = goal
                return reconstruct_path(cameFrom, current)

            openSet.Remove(current)
            closedSet.Add(current)

            for each neighbor of current
                if neighbor in closedSet
                    continue		// Ignore the neighbor which is already evaluated.

                // The distance from start to a neighbor
                tentative_gScore := gScore[current] + dist_between(current, neighbor)

                if neighbor not in openSet	// Discover a new node
                    openSet.Add(neighbor)
                else if tentative_gScore >= gScore[neighbor]
                    continue		// This is not a better path.

                // This path is the best until now. Record it!
                cameFrom[neighbor] := current
                gScore[neighbor] := tentative_gScore
                fScore[neighbor] := gScore[neighbor] + heuristic_cost_estimate(neighbor, goal)

         */
    }
}
