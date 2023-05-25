using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections.Generic;

namespace BBUnity.Actions
{
    public class EatFood : MonoBehaviour
    {
        [Action("survival/EatFood")]
        public class Eat : GOAction
        {
            Inventory inventory;
            Hunger hunger;
            Eatable foodToEat;
            bool hasFoodToEat;

            public override void OnStart()
            {
                inventory = FindObjectOfType<Inventory>();
                hunger = GameObject.FindObjectOfType<Hunger>();
                hasFoodToEat = FindObjectOfType<Inventory>().amountOfFood > 0;
            }

            public override TaskStatus OnUpdate()
            {
                if (hasFoodToEat)
                {
                    Survivor.instance.GetComponent<Hunger>().satiation += inventory.getLeastPerishableFood().nutritionalValue;
                    Debug.Log("ate some food");
                    return TaskStatus.COMPLETED;
                }
                Debug.Log("no more food");
                return TaskStatus.FAILED;
            }
        }
    }

}
