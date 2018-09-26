using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIPlayerStatus : MonoBehaviour
    {
        public Text stamina;

        public void UpdateStamina(int v)
        {
            stamina.text = v.ToString();
        }
    }
}

