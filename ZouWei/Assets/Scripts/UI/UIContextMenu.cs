using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIContextMenu : UIBase
    {
        public GameObject cellPrefab;
        private ScrollRect _scrollRect;

        private void Start()
        {
            _scrollRect = GetComponent<ScrollRect>();
        }

        public override void FillData(object data)
        {
            IContext context = data as IContext;
            List<UIContextMenuItemData> list = context.GetMenuItemData();
            FillMenuItemCells(list);
        }

        protected virtual void FillMenuItemCells(List<UIContextMenuItemData> list)
        {
            for(int i=0; i<list.Count ; i++)
            {
                GameObject cell = Instantiate(cellPrefab);
                cell.transform.SetParent(_scrollRect.content);
                cell.GetComponent<UIBattleMenuItem>().FillData(list[i]);
            }
        }
    }
}
