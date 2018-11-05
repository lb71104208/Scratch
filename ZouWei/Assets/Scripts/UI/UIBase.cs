using Common;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIBase : MonoBehaviour
    {
        protected List<string> ntfTypeList;

        private void Awake()
        {
            ntfTypeList = new List<string>();
        }

        public virtual void OnCreate()
        {
            
        }

        public virtual void FillData(object data)
        {

        }

        public void RegistObserver()
        {
            foreach (string ntf in ntfTypeList)
            {
                EventManager.Instance.AddObserver(ntf, this);
            }
        }

        public virtual void OnHandleNtf(string ntfType, object data)
        {

        }
    }
}

