using UnityEngine;

public class Log : MonoBehaviour
{
    [HideInInspector] public float health;
    public GameObject flame;
    [SerializeField] float depletionRate;
    public LogState state;
    MeshRenderer mesh;
    
    void Awake() => flame = transform.GetChild(0).gameObject;
    void Start()
    {
        health = 10;
        depletionRate = .1f;
        
        mesh = GetComponent<MeshRenderer>();
        
        flame.SetActive(false);
    }

    void Update()
    {
        if (state == LogState.INVISIBLE)
        {
            mesh.enabled = false;
        }
        if (state == LogState.VISIBLE)
        {
            mesh.enabled = true;
        }
        if (state == LogState.BURNING)
        {
            mesh.enabled = true;
            burn();
            flame.SetActive(true);
        }
    }
    public void burn()
    {
        health -= depletionRate * Time.deltaTime;
    }
}

public enum LogState
{
    INVISIBLE, VISIBLE, BURNING
}
