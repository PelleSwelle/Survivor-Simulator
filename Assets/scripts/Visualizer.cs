using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.AI;

public class Visualizer : MonoBehaviour
{
    [SerializeField] Toggle destinationsToggle, sightToggle, poisToggle;
    bool destinationsVisible, rangesVisible, poisVisible;

    // get all moving entities
    Survivor survivor;
    [SerializeField] Transform deerParent, wolvesParent;
    List<Wolf> wolves;
    List<Deer> deers;
    List<GameObject> rangeRings;
    List<GameObject> pois;

    void Start()
    {
        
        destinationsVisible = false;
        rangesVisible = false;
        poisVisible = false;

        


        destinationsToggle.onValueChanged.AddListener( delegate {
            toggleDestinationsVisible();
        });

        sightToggle.onValueChanged.AddListener( delegate {
            toggleRangesVisible();
        });

        poisToggle.onValueChanged.AddListener( delegate {
            togglePoisVisible();
        });
        fillLists();
    }

    void Update()
    {
        if (destinationsVisible)
        {
            setDeerLines();
            setWolfLines();
            setSurvivorLine();
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

        if (poisVisible)
        {
            foreach (GameObject poi in pois)
            {
                MeshRenderer mesh = poi.GetComponent<MeshRenderer>();
                mesh.enabled = !mesh.enabled;
            }
        }
    }

    void setSurvivorLine()
    {
        LineRenderer line = Survivor.instance.GetComponent<LineRenderer>();
        NavMeshAgent agent = Survivor.instance.GetComponent<NavMeshAgent>();

        setLinePositions(agent, line, Color.green);
    }

    void setWolfLines()
    {
        foreach (Wolf wolf in wolves)
        {
            LineRenderer line = wolf.GetComponent<LineRenderer>();
            NavMeshAgent agent = wolf.GetComponent<NavMeshAgent>();
            setLinePositions(agent, line, Color.red);
        }
    }
    void setDeerLines()
    {
        foreach (Deer deer in deers)
        {
            LineRenderer line = deer.GetComponent<LineRenderer>();
            NavMeshAgent agent = deer.GetComponent<NavMeshAgent>();

            setLinePositions(agent, line, Color.blue);
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

    void togglePoisVisible() => poisVisible = !poisVisible;
    
    void toggleDestinationsVisible() => destinationsVisible = !destinationsVisible;
    void toggleRangesVisible() => rangesVisible = !rangesVisible;

    void fillLists()
    {
        deers = new List<Deer>();
        wolves = new List<Wolf>();
        rangeRings = new List<GameObject>();
        pois = new List<GameObject>();

        rangeRings.AddRange(GameObject.FindGameObjectsWithTag("rangeRing"));

        pois.AddRange(GameObject.FindGameObjectsWithTag("pointOfInterest"));
        
        foreach (Transform deerTransform in deerParent)
            deers.Add(deerTransform.GetComponent<Deer>());

        foreach (Transform wolfTransform in wolvesParent)
            wolves.Add(wolfTransform.GetComponent<Wolf>());
    }
}
