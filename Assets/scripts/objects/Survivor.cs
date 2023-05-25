using UnityEngine;
using TMPro;

public class Survivor : MonoBehaviour
{
    public static Survivor instance { get; private set; }
    public int heldWood, maxHeldWood = 4;
    public int ammo;
    public float seeRange = 10;
    public GameObject rangeRing;

    bool isAlive;

    void Awake() => instance = this;

    void OnValidate() => rangeRing.transform.localScale = new Vector3(seeRange, seeRange, seeRange);

    
    void Start()
    {
        ammo = 10;
        isAlive = true;
        
    }

    void Update() 
    {
        isAlive = GetComponent<Health>().value > 0;
        
        if (!isAlive)
            Debug.Log("survivor iz ded");
    }

    void putWood(Fillable target) => target.add(heldWood);
}
