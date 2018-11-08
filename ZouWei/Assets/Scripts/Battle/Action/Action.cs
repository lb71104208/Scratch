using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleField
{
    public class Action
    {
        protected Actor source;
        protected Actor target;
        protected EBattleActionType actionType;

        public Action(Actor s, Actor t, EBattleActionType type )
        {
            source = s;
            target = t;
            actionType = type;
        }

        public virtual void Execute()
        {

        }
    }

}
