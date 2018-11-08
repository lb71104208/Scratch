using Common;
using UnityEngine.Events;

namespace UI
{
    public class UIContextMenuItemData
    {
        public EBattleActionType battleActionType;
        public string actionString;
        public UnityAction<object> actionListener;

        public UIContextMenuItemData(EBattleActionType type, UnityAction<object> listener)
        {
            battleActionType = type;
            actionString = type.ToString();
            actionListener = listener;
        }
    }
}