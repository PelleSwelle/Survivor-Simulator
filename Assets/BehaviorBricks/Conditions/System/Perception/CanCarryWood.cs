using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBUnity.Conditions;
using Pada1.BBCore;

namespace BBUnity.Conditions
{
    [Condition("CanCarryWood")]
    public class CanCarryWood : GOCondition
    {
        public override bool Check()
        {
            Survivor survivor = Survivor.instance;
            return Inventory.instance.logsOfWood < Inventory.instance.maxLogs;
        }
    }

}
