using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("ShootDeer")]
    public class shootDeer : GOAction
    {
        [InParam("Deer")] GameObject deer;
        
        Rifle rifle;
        LineRenderer line;
        public override void OnStart()
        {
            rifle = Rifle.instance;
            line = Rifle.instance.line;
            rifle.aim(deer.transform.position);
            rifle.shoot();
        }
        public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;
    }

}
