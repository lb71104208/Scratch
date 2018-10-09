using Common;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIBase : MonoBehaviour
    {
        protected List<string> ntfType;

        private void Awake()
        {
            ntfType = new List<string>();
        }

        public virtual void OnCreate()
        {

        }

        public void RegistObserver()
        {
            foreach (string ntf in ntfType)
            {
                EventManager.Instance.AddObserver(ntf, this);
            }
        }

        public virtual void OnHandleNtf(string ntfType, object data)
        {

        }
    }
}

