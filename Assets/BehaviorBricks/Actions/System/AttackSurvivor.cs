using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("attackSurvivor")]
    public class AttackSurvivor : GOAction
    {
        Wolf wolf;
        public override void OnStart()
        {
            wolf = gameObject.GetComponent<Wolf>();
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            
            if (Survivor.instance.health <= 0)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }

}
