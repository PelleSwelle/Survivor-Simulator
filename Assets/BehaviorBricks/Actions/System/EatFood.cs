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
            Hunger hunger;
            Eatable foodToEat;
            bool hasFoodToEat;

            public override void OnStart()
            {
                hunger = GameObject.FindObjectOfType<Hunger>();
                hasFoodToEat = Inventory.instance.amountOfFood > 0;
            }

            public override TaskStatus OnUpdate()
            {
                if (hasFoodToEat)
                {
                    Survivor.instance.GetComponent<Hunger>().satiation += Inventory.instance.getLeastPerishableFood().nutritionalValue;
                    Debug.Log("ate some food");
                    return TaskStatus.COMPLETED;
                }
                Debug.Log("no more food");
                return TaskStatus.FAILED;
            }
        }
    }

}
