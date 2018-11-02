namespace Common
{
    public enum ELevel
    {
        World,
        City,
        Battle
    }
    public enum ActorState
    {
        Active,
        Moving,
        Attacking,
        Consumed
    }

    public enum EMap
    {
        BattleTerrainMap
    }

    public enum EPlayerMoveDirection
    {
        NONE = 0,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public enum EPlayerControlMode
    {
        KEYBOARD,
        MOUSE
    }

    public class CommonDefine
    {
       
    }

    public class EventName
    {
        
    }

    public class NotificationType
    {
        public const string PLAYER_STAMINA_CHANGE = "player_stamina_change";
    }

    public class UIName
    {
        public const string UI_PLAYER_STATUS = "ui_player_status";
        public const string UI_GAME_CONTROL = "ui_game_control";
        public const string UI_CONTEXT_MENU = "ui_context_menu";
    }
}
