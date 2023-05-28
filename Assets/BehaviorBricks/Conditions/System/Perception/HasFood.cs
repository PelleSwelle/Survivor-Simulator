using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;

namespace BBUnity
{
    [Condition("HasFood")]
    public class HasFood : GOCondition
    {
        public override bool Check() => Inventory.instance.amountOfFood > 0;
    }
}
