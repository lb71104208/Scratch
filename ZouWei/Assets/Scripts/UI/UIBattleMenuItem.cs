using Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UIBattleMenuItem : MonoBehaviour
    {
        public Text actionText;
        public Button actionBtn;

        private EBattleActionType _actionType;
        private UnityAction<object> _actionListener;

        private void Awake()
        {
            actionBtn.onClick.AddListener(OnActionBtnClick);
        }

        public void FillData(UIContextMenuItemData data)
        {
            actionText.text = data.actionString;
            _actionListener = data.actionListener;
        }

        private void OnActionBtnClick()
        {
            _actionListener(null);
        }

        
    }
}
