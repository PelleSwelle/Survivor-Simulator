using UnityEngine;
using TMPro;

public class Survivor : MonoBehaviour
{
    public static Survivor instance { get; private set; }
    public float health;
    [SerializeField] TMP_Text statusText;
    public int heldWood, maxHeldWood = 4;

    bool isAlive;

    void Awake() => instance = this;
    
    void Start() => isAlive = true;

    void Update() 
    {
        isAlive = GetComponent<Health>().value > 0;
        
        if (!isAlive)
            Debug.Log("survivor iz ded");
    }

    void putWood(Fillable target) => target.add(heldWood);

    public void updateStatusText(string text) => statusText.text = text;
}
