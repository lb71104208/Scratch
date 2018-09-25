using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Game
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void Initialize()
        {
            
        }
    }
}

