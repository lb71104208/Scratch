using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace BattleField
{
    public class ActionRequestMoveRange : Action
    {
        public ActionRequestMoveRange(Actor s, Actor t, EBattleActionType type) : base(s, t, type)
        {
        }
    }
}