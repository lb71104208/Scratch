﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class City : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("Enters city!");
            }
        }
    }
}

