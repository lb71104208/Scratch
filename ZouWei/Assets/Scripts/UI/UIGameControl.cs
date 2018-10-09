using UnityEngine;
using UnityEngine.UI;
using Game;

namespace UI
{
    public class UIGameControl : UIBase
    {
        public Button btnNextTurn;

        public override void OnCreate()
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

