using UnityEngine;

public class Hunger : MonoBehaviour
{
    public float satiation;
    public float depletionRate;
    public float maxSatiation;
    public float hungryThreshold = 40;
    public bool isHungry;

    void Start()
    {
        depletionRate = 1;
        maxSatiation = 100;
        satiation = 50;
    }

    public void eat(Eatable food)
    {
        Inventory inventory = GameObject.FindObjectOfType<Inventory>();
        if (inventory.food.Contains(food))
        {
            inventory.get(food);
            satiation += food.nutritionalValue;
        }
    }

    void Update() 
    {
        isHungry = satiation < hungryThreshold;
        satiation -= depletionRate * Time.deltaTime;
    }
}
