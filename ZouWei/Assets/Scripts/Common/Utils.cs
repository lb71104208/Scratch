using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Utils
    {
        public static Vector3Int Vector3ToVector3Int(Vector3 vec)
        {
            return new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z);
        }

        public static Vector2Int Vector2ToVector2Int(Vector2 vec)
        {
            return new Vector2Int((int)vec.x, (int)vec.y);
        }
    }
} 