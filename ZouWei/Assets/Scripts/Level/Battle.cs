using BattleField;
using MainPlayer;

namespace Game
{
    public class Battle : LevelBase
    {
        public Map movementMap;

        public override void OnEnter()
        {
            Player player = PlayerManager.Instance.MainPlayer;
            Actor actor = player.GetComponent<Actor>();
            movementMap.ShowActorMovableTiles(actor);
        }
    }
}