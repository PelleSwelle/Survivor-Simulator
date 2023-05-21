using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.AI;

public class Visualizer : MonoBehaviour
{
    [SerializeField] Toggle destinationsToggle, sightToggle;
    bool destinationsVisible, rangesVisible;

    // get all moving entities
    Survivor survivor;
    [SerializeField] Transform deerParent, wolvesParent;
    List<Wolf> wolves;
    List<Deer> deers;
    List<GameObject> rangeRings;

    void Start()
    {
        rangeRings = new List<GameObject>();
        rangeRings.AddRange(GameObject.FindGameObjectsWithTag("rangeRing"));
        destinationsVisible = false;
        rangesVisible = false;

        destinationsToggle.onValueChanged.AddListener( delegate {
            toggleDestinationsVisible();
        });

        sightToggle.onValueChanged.AddListener( delegate {
            toggleRangesVisible();
        });
        fillLists();
    }

    void Update()
    {
        if (destinationsVisible)
        {
            // ********** DEER **********
            foreach (Deer deer in deers)
            {
                LineRenderer line = deer.GetComponent<LineRenderer>();
                NavMeshAgent agent = deer.GetComponent<NavMeshAgent>();

                setLinePositions(agent, line, Color.blue);
            }

            // ********** WOLVES **********
            foreach (Wolf wolf in wolves)
            {
                LineRenderer line = wolf.GetComponent<LineRenderer>();
                NavMeshAgent agent = wolf.GetComponent<NavMeshAgent>();
                setLinePositions(agent, line, Color.red);
            }
        }

        if (rangesVisible)
        {
            foreach(GameObject ring in rangeRings)
                ring.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            foreach (GameObject ring in rangeRings)
                ring.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void setLinePositions(NavMeshAgent agent, LineRenderer line, Color color)
    {
        line.startColor = color;
        line.endColor = color;
        if (agent.destination != null)
        {
            line.SetPosition(0, agent.transform.position);
            line.SetPosition(1, agent.destination);
        }
        else
            throw new System.Exception("no destination set");
    }
    
    void toggleDestinationsVisible()
    {
        destinationsVisible = !destinationsVisible;
        
    }
    void toggleRangesVisible()
    {
        rangesVisible = !rangesVisible;

    }

    void fillLists()
    {
        deers = new List<Deer>();
        wolves = new List<Wolf>();
        
        foreach (Transform deerTransform in deerParent)
            deers.Add(deerTransform.GetComponent<Deer>());
        foreach (Transform wolfTransform in wolvesParent)
            wolves.Add(wolfTransform.GetComponent<Wolf>());
    }
}
