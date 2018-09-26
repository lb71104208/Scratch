using UnityEngine;
using UnityEngine.UI;
using Game;

namespace UI
{
    public class UIGameControl : MonoBehaviour
    {
        public Button btnNextTurn;

        private void Awake()
        {
            btnNextTurn.onClick.AddListener(OnBtnNextTurn);
        }

        private void OnBtnNextTurn()
        {
            GamaManager.Instance.NextTurn();
        }

        private void OnDestroy()
        {
            btnNextTurn.onClick.RemoveAllListeners();
        }
    }
}

