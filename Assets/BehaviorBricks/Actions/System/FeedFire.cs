using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("survival/FeedFire")]
    public class FeedFire : GOAction
    {
        private WoodPile woodPile;
        private Fire fire;

        public override void OnStart()
        {
            woodPile = GameObject.Find("woodPile").GetComponent<WoodPile>();
            fire = GameObject.Find("fire").GetComponent<Fire>();

            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            if (woodPile.numberOfLogs == 0)
                return TaskStatus.FAILED;

            woodPile.numberOfLogs--;
            fire.add();
            return TaskStatus.COMPLETED;
        }
    }

}
