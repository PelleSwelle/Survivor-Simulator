using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

namespace BBUnity.Actions
{
    [Action("Eat")]
    public class Eat : GOAction
    {
        Inventory inventory = GameObject.FindObjectOfType<Inventory>();
        Hunger hunger = GameObject.FindObjectOfType<Hunger>();
        Eatable foodToEat;

        public override void OnStart()
        {
            foodToEat = inventory.food[Random.Range(0, inventory.food.Count)];
            hunger.eat(foodToEat);
        }
    }
}