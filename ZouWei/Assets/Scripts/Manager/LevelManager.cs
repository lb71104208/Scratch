using Common;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelManager : Singleton<LevelManager>
    {
        public void Initialize()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            PlayerManager.Instance.OnEnterScene(scene.buildIndex);
        }

        public void EnterLevel(ELevel level)
        {
            SceneManager.LoadScene((int)level);
        }


    }
}
