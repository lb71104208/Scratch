using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using MainPlayer;

namespace UI
{
    public class UIPlayerStatus : UIBase
    {
        public Text stamina;

        public override void OnCreate()
        {
            ntfTypeList.Add(NotificationType.PLAYER_STAMINA_CHANGE);
        }

        public override void FillData(object data)
        {
            Player player = data as Player;
            stamina.text = player.CurrentStamina.ToString();
        }

        public override void OnHandleNtf(string ntfType, object data)
        {
            switch(ntfType)
            {
                case NotificationType.PLAYER_STAMINA_CHANGE:
                    OnPlayerStaminaChange(data);
                    break;

                default: break;
            }
        }

        private void OnPlayerStaminaChange(object obj)
        {
            int v = (int)obj;
            stamina.text = v.ToString();
        }

    }
}

