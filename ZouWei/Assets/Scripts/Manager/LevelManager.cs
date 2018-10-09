using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelManager : Singleton<LevelManager>
    {
        private LevelBase _currentLevel;
        public LevelBase CurrentLevel { get { return _currentLevel; } }

        public void Initialize()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            PlayerManager.Instance.OnEnterScene(scene.buildIndex);
            _currentLevel = Object.FindObjectOfType<LevelBase>();
            _currentLevel.OnEnter();
        }

        public void EnterLevel(ELevel level)
        {
            SceneManager.LoadScene((int)level);
        }


    }
}
