using UnityEngine;

public class DirectionVisualizer : MonoBehaviour
{
    LineRenderer line;

    bool active;
    Vector3 target;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        if (line == null)
            line = gameObject.AddComponent<LineRenderer>();
    }

    void Update()
    {
        // target = gameObject.GetComponent<BehaviorExecutor>().behavior
        if (active)
        {
            line.SetPosition(1, target);
            line.enabled = true;
        }
        else
            line.enabled = false;
    }

    public void toggle() => active = !active;
}
