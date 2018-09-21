using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerProperty : MonoBehaviour
    {
        private int maxStamina = 10;

        private int curStamina = 0;

        private void Start()
        {
            curStamina = maxStamina;
        }
    }
}

