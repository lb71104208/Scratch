using Common;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : SingletonMonobehaviour<UIManager>
    {
        private Dictionary<string, string> _uiPrefabPathDic;
        private Transform _canvas;
        private Dictionary<string, UIBase> _openedUIDic;

        public void Initialize()
        {
            _uiPrefabPathDic = new Dictionary<string, string>();
            _canvas = Object.FindObjectOfType<Canvas>().transform;
            _openedUIDic = new Dictionary<string, UIBase>();

            RegistUIPrefabPath();
        }

        private void RegistUIPrefabPath()
        {
            _uiPrefabPathDic.Add(UIName.UI_PLAYER_STATUS, "Prefabs/UI/UIPlayerStatus");
            _uiPrefabPathDic.Add(UIName.UI_GAME_CONTROL, "Prefabs/UI/UIGameControl");
            _uiPrefabPathDic.Add(UIName.UI_CONTEXT_MENU, "Prefabs/UI/UIContextMenu");
        }

        public void OpenUI(string uiName, object data = null)
        {
            if(_openedUIDic.ContainsKey(uiName))
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
            ui.UIName = uiName;

            _openedUIDic.Add(uiName, ui);
        }

        private GameObject LoadUI(string path)
        {
            GameObject uiObj = Resources.Load<GameObject>(path);
            uiObj = Instantiate(uiObj) as GameObject;
            return uiObj;
        }

        public void ShowContextMenu(Vector3 position,  object data)
        {
            string uiName = UIName.UI_CONTEXT_MENU;
            if (_openedUIDic.ContainsKey(uiName))
            {
                return;
            }

            GameObject uiObj = LoadUI(_uiPrefabPathDic[uiName]);
            uiObj.transform.SetParent(_canvas.transform);
       
            uiObj.transform.localPosition = position;

            UIBase ui = uiObj.GetComponent<UIBase>();
            ui.OnCreate();
            ui.RegistObserver();
            ui.FillData(data);

            _openedUIDic.Add(uiName, ui);
        }

        public void CloseUI(string uiName)
        {
            if(_openedUIDic.ContainsKey(uiName))
            {
                _openedUIDic[uiName].OnClose();
                Destroy(_openedUIDic[uiName]);
                _openedUIDic.Remove(uiName);
            }
        }
    }
}
