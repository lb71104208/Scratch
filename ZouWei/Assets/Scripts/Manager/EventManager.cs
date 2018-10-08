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
            AddListener("AAA", Method);
            _actionDic["AAA"].Invoke(null);
        }

        public void AddListener(string eventName, Action<object> action)
        {
            if(!_actionDic.ContainsKey(eventName))
            {
                Action<object> act =  default(Action<object>);
                _actionDic.Add(eventName, act);
            }
            _actionDic[eventName] += action;
        }

        private void Method(object obj)
        {
            Delegate[] list =  _actionDic["AAA"].GetInvocationList();
        }

    }
}

