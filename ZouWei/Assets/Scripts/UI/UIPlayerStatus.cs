using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

namespace UI
{
    public class UIPlayerStatus : UIBase
    {
        public Text stamina;

        private void OnPlayerStaminaChange(object obj)
        {
            int v = (int)obj;
            stamina.text = v.ToString();
        }

    }
}

