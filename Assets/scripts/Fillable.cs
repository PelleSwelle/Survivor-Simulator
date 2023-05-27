using UnityEngine;
using System.Collections.Generic;

public abstract class Fillable : MonoBehaviour
{
    [SerializeField] GameObject logPrefab;
    protected int maxNumberOfLogs = 10;
    public int numberOfLogs;
    float closeDistance = 2;
    [SerializeField] protected List<Log> logPrefabs; // for vizualizing

    void Update() => isInRange = Vector3.Distance(Survivor.instance.transform.position, transform.position) < closeDistance;

    public bool isInRange;
    public void add()
    {
        if (numberOfLogs < maxNumberOfLogs)
        {
            numberOfLogs++;
            showLatest();
        }
        else 
            Debug.Log("No more room");
    }

    public void add(int amount)
    {
        for (int i = 0; i < amount; i++)
            add();
    }
    public void take()
    {
        if (numberOfLogs > 0)
        {
            numberOfLogs--;
            hideLatest();
        }
        Debug.Log("There are no more logs to take");
    }

    public void fill()
    {
        for (int i = numberOfLogs; i < maxNumberOfLogs ; i++)
            add();
    }

    void hideLatest()
        => transform.GetChild(numberOfLogs - 1).GetComponent<Log>().state = LogState.INVISIBLE;

    void showLatest()
    {
        if (this.name == "bonfire")
            transform.GetChild(numberOfLogs - 1).GetComponent<Log>().state = LogState.BURNING;
        else if (this.name == "woodPile")
            transform.GetChild(numberOfLogs - 1).GetComponent<Log>().state = LogState.VISIBLE;
    }
}
