using UnityEngine;
using System.Collections.Generic;

public abstract class Fillable : MonoBehaviour
{
    [SerializeField] GameObject logPrefab;
    public int maxNumberOfLogs = 10;
    public int numberOfLogs;
    float closeDistance = 2;
    [SerializeField] protected List<Log> logPrefabs; // for vizualizing

    public bool isInRange() => Vector3.Distance(Survivor.instance.transform.position, transform.position) < closeDistance;

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

    public void add(int amount) // TODO: fix this
    {
        if (numberOfLogs < maxNumberOfLogs)
        {
            for (int i = 0; i < amount; i++)
                add();
        }
    }
    public void take()
    {
        if (numberOfLogs > 0)
        {
            numberOfLogs--;
            hideLatest();
        }
        else
            Debug.Log("There are no more logs to take");
    }

    public void fill()
    {
        for (int i = numberOfLogs; i < maxNumberOfLogs ; i++)
            add();
    }

    void hideLatest()
    {
        Log log = transform.GetChild(numberOfLogs).GetComponent<Log>();
        log.state = LogState.INVISIBLE;
    }

    void showLatest()
    {
        Log log = transform.GetChild(numberOfLogs).GetComponent<Log>();

        if (this.name == "bonfire")
            log.state = LogState.BURNING;
        else if (this.name == "woodPile")
            log.state = LogState.VISIBLE;
    }
}
