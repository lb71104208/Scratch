using Common;
using UI;

namespace Game
{
    public class World : LevelBase
    {
        public override void OnEnter()
        {
            OpenDefaultUI();
        }

        private void OpenDefaultUI()
        {
            UIManager.Instance.OpenUI(UIName.UI_GAME_CONTROL);
            UIManager.Instance.OpenUI(UIName.UI_PLAYER_STATUS, PlayerManager.Instance.MainPlayer);
        }

    }
}


