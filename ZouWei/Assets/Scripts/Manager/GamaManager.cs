using Common;
using UI;

namespace Game
{
    public class GamaManager : SingletonMonobehaviour<GamaManager>
    {
        void Awake()
        {
            EventManager.Instance.Initialize();
            LevelManager.Instance.Initialize();
            PlayerManager.Instance.Initialize();
            UIManager.Instance.Initialize();
        }

        public void NextTurn()
        {
            PlayerManager.Instance.RefreshPlayerStatus();
        }
    }
}

