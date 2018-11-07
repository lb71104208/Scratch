using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBattleMenuItem : MonoBehaviour
    {
        public Text actionText;

        public void FillData(UIContextMenuItemData data)
        {
            actionText.text = data.actionString;
        }
    }
}
