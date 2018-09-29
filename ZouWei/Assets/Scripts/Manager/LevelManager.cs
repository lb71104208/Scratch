using Common;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelManager : Singleton<LevelManager>
    {
        public void EnterLevel(ELevel level)
        {
            SceneManager.LoadScene(level.ToString());
        }
    }
}
