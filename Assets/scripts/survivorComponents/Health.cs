using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject hurtPrefab;
    public float value;
    public int maxValue;

    void Start() => value = maxValue;

    void Update()
    {
        if (value <= 0)
        {
            Destroy(GetComponent<BehaviorExecutor>());
            transform.rotation = new Quaternion(90, 0, 0, 0);
        }
    }

    public void decrease(int amount)
    {
        StartCoroutine(displayIsHurt());
        value -= amount;
    }

    public void increase(int amount) 
    {
        if (value < maxValue)
            value += amount;
    }
    
    IEnumerator displayIsHurt()
    {
        Vector3 above = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject hurtIndicator = Instantiate(hurtPrefab, above, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(hurtIndicator);
    }
}
