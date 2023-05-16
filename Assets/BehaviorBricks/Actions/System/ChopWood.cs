using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("survival/ChopWood")]
    public class ChopWood : GOAction
    {
        Transform survivor;
        [InParam("treeToChop")] public Transform treeToChop;
        private float timeToChop = 3f;
        private float timeLeft;
        public override void OnStart()
        {
            Survivor.instance.updateStatusText("chopping wood");
            treeToChop = Util.getNearestTree();
            survivor = Survivor.instance.transform;
            timeLeft = timeToChop;
        }

        public override TaskStatus OnUpdate()
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                return TaskStatus.RUNNING;
            }
            GameObject.Destroy(treeToChop.gameObject);
            Survivor.instance.heldWood += 4;
            return TaskStatus.COMPLETED;
        }

    }
}
