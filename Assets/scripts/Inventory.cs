using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] TMP_Text meatText, fishText, rationsText, waterText, woodText;
    public static Inventory instance { get; private set; }
    public List<Eatable> rations;
    public List<Eatable> meat;
    public List<Eatable> fish;
    public int amountOfFood;
    public int unitsOfWater;
    public int logsOfWood, maxLogs = 5;

    void Awake() => instance = this;
    void Start()
    {
        rations = new List<Eatable>();
        meat = new List<Eatable>();
        fish = new List<Eatable>();
        addRation();

        unitsOfWater = 2;
    }

    void Update()
    {
        amountOfFood = meat.Count + fish.Count + rations.Count;
        updateUI();
    }

    void addRation() => rations.Add(new Ration());
    void addMeat() => meat.Add(new Meat());
    void addFish() => fish.Add(new Fish());

    public void get(Eatable _food)
    {
        if (rations.Contains(_food))
            rations.Remove(_food);
    }

    void updateUI()
    {
        meatText.SetText(meat.Count.ToString());
        fishText.SetText(fish.Count.ToString());
        rationsText.SetText(rations.Count.ToString());
        waterText.SetText(unitsOfWater.ToString());
        // woodText.SetText()
    }

    public Eatable getLeastPerishableFood()
    {
        Eatable food = null;
        if (rations.Count > 0)
        {
            food = rations[0];
            rations.Remove(food);
        }
        else if (fish.Count > 0)
        {
            food = fish[0];
            fish.Remove(food);
        }
        else if (meat.Count > 0)
        {
            food = meat[0];
            fish.Remove(food);
        }

        return food;
    }
}
