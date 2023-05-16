using UnityEngine;
public class Deer : MonoBehaviour
{
    public int health;
    public bool isNear;
    BehaviorExecutor behaviorExecutor;
    void Awake()
    {
        behaviorExecutor = GetComponent<BehaviorExecutor>();
        GameObject wanderArea = GameObject.Find("terrain");
        behaviorExecutor.SetBehaviorParam("area", wanderArea);
    }
    void Start() => health = 2;


    // bool calculateIsNear() 
    // {
    //     Rifle rifle = Rifle.instance;
    //     return Vector3.Distance(transform.position, rifle.transform.position) < rifle.range;
    // }


    
    void OnCollisionEnter(Collision collision) 
    { 
        if (collision.gameObject.tag == "bullet") { health--; } 
    }
}
