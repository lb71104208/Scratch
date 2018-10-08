using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class EventManager : Singleton<EventManager>
    {
        private Dictionary<string, Action<object>> _actionDic;

        public void Initialize()
        {
            _actionDic = new Dictionary<string, Action<object>>();
        }

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


    }
}

