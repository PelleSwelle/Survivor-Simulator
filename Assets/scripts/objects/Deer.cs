using UnityEngine;
using System.Collections;

public class Deer : MonoBehaviour
{
    public bool isAlive;
    Health health;
    int amountOfMeat = 5;
    void Start() => health = GetComponent<Health>();
    void Update()
    {
        if (health.value <= 0) 
        { 
            isAlive = false;

            StartCoroutine(disappearAfter2Seconds()); 
        }
    }

    IEnumerator disappearAfter2Seconds()
    {
        yield return new WaitForSeconds(2);
        Inventory inventory = FindObjectOfType<Inventory>();
        for (int i = 0; i < amountOfMeat; i++)
        {
            inventory.meat.Add(new Meat());
        }
        Debug.Log("added 5 meat to inventory");
        Destroy(this.gameObject);
    }
}
