using Pada1.BBCore;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsDeerClose")]
    public class IsDeerClose : GOCondition
    {
        public Transform deerParent;

        public override bool Check() 
        {
            // return 
            deerParent = GameObject.Find("deerParent").transform;
            foreach (Transform _deer in deerParent)
            {
                float distance = Vector3.Distance(gameObject.transform.position, _deer.position);
                if (distance < 10)
                {
                    Logger.instance.displayDeerInRange(true);
                    Survivor.instance.GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
                    return true;
                }
            }
            Logger.instance.displayDeerInRange(false);
            return false;
        }
    }
}