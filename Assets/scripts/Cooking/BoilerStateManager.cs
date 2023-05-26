using UnityEngine;
using TMPro;

public class BoilerStateManager : MonoBehaviour
{
    public TMP_Text statusText;
    public Material dirtyMaterial, boilingMaterial, frozenMaterial, cleanMaterial, emptyMaterial;
    [SerializeField] MeshRenderer mesh;
    BoilerBaseState currentState;
    public BoilingState boiling = new BoilingState();
    public FrozenState frozen = new FrozenState();
    public EmptyState empty = new EmptyState();
    public DirtyState dirty = new DirtyState();
    public CleanState clean = new CleanState();

    void Start()
    {
        statusText = GetComponent<TMP_Text>();
        currentState = dirty;

        currentState.EnterState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(BoilerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void takeWater()
    {
        Thirst thirst = Survivor.instance.GetComponent<Thirst>();
        thirst.waterLevel = thirst.maxWaterLevel;
        Debug.Log("took some water from the boiler.");
        GameObject.FindObjectOfType<Inventory>().unitsOfWater ++;
    }
}
