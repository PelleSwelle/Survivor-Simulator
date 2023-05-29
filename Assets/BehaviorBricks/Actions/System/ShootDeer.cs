using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;


namespace BBUnity.Actions
{
    [Action("ShootDeer")]
    public class ShootDeer : GOAction
    {
        [InParam("delay", DefaultValue=30)] public int delay;
        [InParam("deerToShoot")] public GameObject deerToShoot;
        int elapsed = 0;
        public override TaskStatus OnUpdate()
        {
            if (delay > 0)
            {
                ++elapsed;
                elapsed %= delay;

                if (elapsed != 0)
                    return TaskStatus.RUNNING;
            }

            deerToShoot.GetComponent<Health>().decrease(1);
            base.OnUpdate();
            return TaskStatus.COMPLETED;
        }
    }
}
