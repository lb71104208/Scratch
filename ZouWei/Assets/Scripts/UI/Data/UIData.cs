using Common;

namespace UI
{
    public class UIContextMenuItemData
    {
        public EBattleActionType battleActionType;
        public string actionString;

        public UIContextMenuItemData(EBattleActionType type)
        {
            battleActionType = type;
            actionString = type.ToString();
        }
    }
}