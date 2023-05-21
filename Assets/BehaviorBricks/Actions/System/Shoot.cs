    using Pada1.BBCore;           // Code attributes
    using Pada1.BBCore.Tasks;     // TaskStatus
    using UnityEngine;
 
    [Action("survival/Shoot")]
    public class Shoot : ShootOnce
    {
        [InParam("delay", DefaultValue=30)]
        public int delay;
        int elapsed = 0;
        public override TaskStatus OnUpdate()
        {
            if (delay > 0)
            {
                ++elapsed;
                elapsed %= delay;
                if (elapsed != 0)
                {
                    return TaskStatus.RUNNING;
                }
            }
 
            base.OnUpdate();
            return TaskStatus.RUNNING;
        }
    }