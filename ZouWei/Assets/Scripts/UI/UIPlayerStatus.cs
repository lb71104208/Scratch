using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

namespace UI
{
    public class UIPlayerStatus : MonoBehaviour
    {
        public Text stamina;

        void Awake()
        {
            EventManager.Instance.AddListener(EventName.PLAYER_STAMINA_CHANGE, OnPlayerStaminaChange);
        }

        private void OnPlayerStaminaChange(object obj)
        {
            int v = (int)obj;
            //stamina.text = v.ToString();
        }

        void OnDestroy()
        {
            EventManager.Instance.RemoveListener(EventName.PLAYER_STAMINA_CHANGE, OnPlayerStaminaChange);
        }
    }
}

