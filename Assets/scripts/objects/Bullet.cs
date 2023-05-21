using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "deer" || collision.gameObject.tag == "wolf")
        {
            Debug.Log("Hit " + collision.gameObject.name);
            Health health = collision.gameObject.GetComponent<Health>();
            health.value --;
        }
    }
    void Start() => Destroy(gameObject, 2);
}
