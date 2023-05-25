using Pada1.BBCore;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace BBUnity.Conditions
{
    public class IsDeerDead : GOCondition
    {
        [InParam("deer")] public GameObject closeDeer;
        public override bool Check()
        {
            if( !closeDeer.GetComponent<Deer>().isAlive)
                return true;
            return false;
        }
    }

}
