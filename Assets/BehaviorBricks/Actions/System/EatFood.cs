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
            List<Eatable> availableFood;
            Hunger hunger;
            Eatable foodToEat;

            public override void OnStart()
            {
                inventory = GameObject.FindObjectOfType<Inventory>();
                hunger = GameObject.FindObjectOfType<Hunger>();
                availableFood = inventory.food;
            }

            public override TaskStatus OnUpdate()
            {
                if (availableFood.Count <= 0)
                {
                    Debug.Log("no more food");
                    return TaskStatus.FAILED;
                }
                else 
                {
                    foodToEat = inventory.food[Random.Range(0, inventory.food.Count)];
                    hunger.eat(foodToEat);
                    Debug.Log("ate some food");
                    return TaskStatus.COMPLETED;
                }
            }
        }
    }

}
