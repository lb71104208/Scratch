using Common;
using System.Collections.Generic;

namespace UI
{
    public class BattleActorPlayerContext : IContext
    {
        public List<UIContextMenuItemData> GetMenuItemData()
        {
            List<UIContextMenuItemData> list = new List<UIContextMenuItemData>();

            UIContextMenuItemData data = new UIContextMenuItemData(EBattleActionType.Move);
            list.Add(data);

            data = new UIContextMenuItemData(EBattleActionType.Attack);
            list.Add(data);

            data = new UIContextMenuItemData(EBattleActionType.End_Turn);
            list.Add(data);

            return list;
        }
    }
}

