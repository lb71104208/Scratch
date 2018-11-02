using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface IContext
    {
        List<UIContextMenuItemData> GetMenuItemData();
    }
}

