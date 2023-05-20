using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance { get; private set; }
    public List<Eatable> rations;
    public List<Eatable> meat;
    public List<Eatable> fish;
    public List<Eatable> food;
    public int unitsOfWater;

    void Awake() => instance = this;
    void Start()
    {
        rations = new List<Eatable>();
        meat = new List<Eatable>();
        fish = new List<Eatable>();
        addRation();

        unitsOfWater = 2;

        food = new List<Eatable>();
        food.AddRange(meat);
        food.AddRange(fish);
        food.AddRange(rations);
    }

    void addRation() => rations.Add(new Ration());
    void addMeat() => meat.Add(new Meat());
    void addFish() => fish.Add(new Fish());

    public void get(Eatable _food)
    {
        if (rations.Contains(_food))
            rations.Remove(_food);
    }
}
