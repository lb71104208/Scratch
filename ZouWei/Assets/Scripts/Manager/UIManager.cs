using Common;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : SingletonMonobehaviour<UIManager>
    {
        private Dictionary<string, string> _uiPrefabPathDic;
        private Transform _canvas;
        private List<string> _openedUIList;

        public void Initialize()
        {
            _uiPrefabPathDic = new Dictionary<string, string>();
            _canvas = Object.FindObjectOfType<Canvas>().transform;
            _openedUIList = new List<string>();

            RegistUIPrefabPath();
        }

        private void RegistUIPrefabPath()
        {
            _uiPrefabPathDic.Add(UIName.UI_PLAYER_STATUS, "Prefabs/UI/UIPlayerStatus");
            _uiPrefabPathDic.Add(UIName.UI_GAME_CONTROL, "Prefabs/UI/UIGameControl");
        }

        public void OpenUI(string uiName, object data = null)
        {
            if(_openedUIList.Contains(uiName))
            {
                return;
            }

            GameObject uiObj = LoadUI(_uiPrefabPathDic[uiName]);
            uiObj.transform.SetParent(_canvas.transform);
            uiObj.transform.localPosition = Vector3.zero;
            uiObj.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            //uiObj.transform.localScale = Vector3.one;

            UIBase ui = uiObj.GetComponent<UIBase>();
            ui.OnCreate();
            ui.RegistObserver();
            ui.FillData(data);

            _openedUIList.Add(uiName);
        }

        private GameObject LoadUI(string path)
        {
            GameObject uiObj = Resources.Load<GameObject>(path);
            uiObj = Instantiate(uiObj) as GameObject;
            return uiObj;
        }
    }
}
