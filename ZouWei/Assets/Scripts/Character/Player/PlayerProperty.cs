using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainPlayer
{
    public class PlayerProperty : MonoBehaviour
    {
        public int MaxStamina { 
            get { return _maxStamina; }
            set { _maxStamina = value; }
        }

        private int _maxStamina = 10;
    }
}

