using System;
using System.Collections.Generic;
using UI;

namespace Common
{
    public class EventManager : Singleton<EventManager>
    {
        private Dictionary<string, Action<object>> _actionDic;
        private Dictionary<string, List<UIBase>> _ntfObserverDic;

        public void Initialize()
        {
            _actionDic = new Dictionary<string, Action<object>>();
            _ntfObserverDic = new Dictionary<string, List<UIBase>>();
        }

        #region Action
        public void AddListener(string eventName, Action<object> action)
        {
            if(!_actionDic.ContainsKey(eventName))
            {
                Action<object> act =  default(Action<object>);
                _actionDic.Add(eventName, act);
            }
            _actionDic[eventName] -= action;
            _actionDic[eventName] += action;
        }

        public void RemoveListener(string eventName, Action<object> action)
        {
            if (_actionDic.ContainsKey(eventName))
            {
                _actionDic[eventName] -= action;
            }
        }

        public void SendEvent(string eventName, object obj)
        {
            if(_actionDic!= null)
            {
                if(_actionDic.ContainsKey(eventName))
                {
                    _actionDic[eventName].Invoke(obj);
                }
            }
        }
        #endregion

        #region Notification
        public void AddObserver(string ntfType, UIBase ui)
        {
            if(!_ntfObserverDic.ContainsKey(ntfType))
            {
                _ntfObserverDic.Add(ntfType, new List<UIBase>());
            }

            if(!_ntfObserverDic[ntfType].Contains(ui))
            {
                _ntfObserverDic[ntfType].Add(ui);
            }
        }

        public void RemoveObserver(string ntfType, UIBase ui)
        {
            if (_ntfObserverDic.ContainsKey(ntfType))
            {
                if (_ntfObserverDic[ntfType].Contains(ui))
                {
                    _ntfObserverDic[ntfType].Remove(ui);
                }
            }
        }

        public void SendNotification(string ntfType, object data)
        {
            if(_ntfObserverDic.ContainsKey(ntfType))
            {
                foreach(UIBase ui in _ntfObserverDic[ntfType])
                {
                    ui.OnHandleNtf(ntfType, data);
                }
            }
        }
        #endregion

    }
}

