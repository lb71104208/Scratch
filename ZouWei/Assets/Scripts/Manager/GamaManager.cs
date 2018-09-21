using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GamaManager : MonoBehaviour
    {
        public static GamaManager instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if(instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void InitGame()
        {
            PlayerManager.instance.Initialize();
        }
    }
}

