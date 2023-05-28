using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] TMP_Text meatText, fishText, rationsText, waterText, woodText, fireText, woodPileText;
    [SerializeField] Button meatUp, meatDown, fishUp, fishDown, rationsUp, rationsDown, waterUp, waterDown, fireUp, fireDown, pileUp, pileDown;
    public static Inventory instance { get; private set; }
    public List<Eatable> rations, meat, fish;
    public int amountOfFood;
    public int unitsOfWater, maxUnitsOfWater = 3;
    public int logsOfWood, maxLogs;

    void Awake() => instance = this;
    void Start()
    {
        rations = new List<Eatable>();
        meat = new List<Eatable>();
        fish = new List<Eatable>();
        addRation();
        logsOfWood = 0;
        maxLogs = 5;

        meatUp.onClick.AddListener(() => addMeat());
        meatDown.onClick.AddListener(() => takeMeat());

        fishUp.onClick.AddListener(() => addFish());
        fishDown.onClick.AddListener(() => takeFish());
        
        rationsUp.onClick.AddListener(() => addRation());
        rationsDown.onClick.AddListener(() => takeRation());
        
        waterUp.onClick.AddListener(() => addWater());
        waterDown.onClick.AddListener(() => takeWater());

        fireUp.onClick.AddListener(() => Fire.instance.add());
        fireDown.onClick.AddListener(() => Fire.instance.take());

        pileUp.onClick.AddListener(() => WoodPile.instance.add());
        pileDown.onClick.AddListener(() => WoodPile.instance.take());

        unitsOfWater = 0;
    }



    void takeMeat()
    {
        if (meat.Count > 0)
            meat.Remove(meat[meat.Count-1]);
    }
    void takeWater()
    {
        if (unitsOfWater > 0)
            unitsOfWater --;
    }

    void addWater() => unitsOfWater ++;
    void takeRation()
    {
        if (rations.Count > 0)
            rations.Remove(rations[rations.Count-1]);
    }
    void takeFish()
    {
        if (fish.Count > 0)
            fish.Remove(fish[fish.Count-1]);
    }
    void Update()
    {
        amountOfFood = meat.Count + fish.Count + rations.Count;
        updateUI();
    }

    void addRation() => rations.Add(new Ration());
    void addMeat()
    {
        meat.Add(new Meat());
    }
    void addFish() => fish.Add(new Fish());

    void updateUI()
    {
        meatText.SetText(meat.Count.ToString());
        fishText.SetText(fish.Count.ToString());
        rationsText.SetText(rations.Count.ToString());
        waterText.SetText(unitsOfWater.ToString());
        fireText.SetText(Fire.instance.numberOfLogs.ToString());
        woodText.SetText(logsOfWood.ToString());
        woodPileText.SetText(WoodPile.instance.numberOfLogs.ToString());
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
