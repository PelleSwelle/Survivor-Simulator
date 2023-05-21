using UnityEngine;
using TMPro;

public class Survivor : MonoBehaviour
{
    public static Survivor instance { get; private set; }
    public float health;
    public int heldWood, maxHeldWood = 4;
    LineRenderer line;
    public int ammo;

    bool isAlive;

    void Awake() => instance = this;
    
    void Start()
    {
        ammo = 10;
        line = this.gameObject.GetComponent<LineRenderer>();
        isAlive = true;
    }

    void Update() 
    {
        line.SetPosition(1, Vector3.forward * 10);
        isAlive = GetComponent<Health>().value > 0;
        
        if (!isAlive)
            Debug.Log("survivor iz ded");
    }

    void putWood(Fillable target) => target.add(heldWood);
}
