using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("survival/ChopWood")]
    public class ChopWood : GOAction
    {
        Transform survivor;
        Inventory inventory;
        [InParam("treeToChop")] public GameObject treeToChop;
        private float timeToChop = 3f;
        private float timeLeft;
        public override void OnStart()
        {
            
            Logger.instance.updateTaskText("chopping wood");
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
            Inventory.instance.logsOfWood += 5;
            return TaskStatus.COMPLETED;
        }

    }
}
