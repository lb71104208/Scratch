using BattleField;
using Common;
using System.Collections.Generic;

namespace UI
{
    public class BattleActorPlayerContext : IContext
    {
        private ActorPlayer _actorPlayer;

        public BattleActorPlayerContext()
        {

        }

        public BattleActorPlayerContext(ActorPlayer actorPlayer)
        {
            _actorPlayer = actorPlayer;
        }

        public void OnRequestMoveRange()
        {
            ActionRequestMoveRange requestMoveAction = new ActionRequestMoveRange(_actorPlayer, null, EBattleActionType.Move);
            requestMoveAction.Execute();
        }

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

