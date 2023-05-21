using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public LineRenderer line;
    public static Rifle instance;
    public float range;
    public int ammo;
    bool rangeIsVisible;
    public float reloadTime;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shootForce;
    [SerializeField] float explosionRadius;
    [SerializeField] GameObject rangeSphere;
    public List<Deer> deerInRange;
    AudioSource audioSource;
    bool isLoaded;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instance = this; 
    }
    void Start()
    {
        deerInRange = new List<Deer>();
        reloadTime = 3.0f;
        rangeIsVisible = false;
        range = 50.0f;
        ammo = 10;
    }

    public void toggleRangeIsVisible()
    {
        rangeSphere = transform.GetChild(0).gameObject;
        MeshRenderer rangeRenderer = rangeSphere.GetComponent<MeshRenderer>();
        rangeRenderer.enabled = !rangeRenderer.enabled;
    }

    void Update()
    {
        transform.GetChild(0).transform.localScale = new Vector3(range, range, range);
    }

    // public void shoot() 
    // {
    //     if (isLoaded)
    //     {
    //         Debug.Log("shot");
    //         GameObject bullet = getBullet();
    //         Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();
    //         isLoaded = false;
    //         audioSource.Play();
            
    //         rigidBody.AddForce(Vector3.forward * shootForce, ForceMode.Impulse);

    //         if (Vector3.Distance(transform.position, bullet.transform.position) > range)
    //         Destroy(bullet);
            
    //         ammo--;
    //         reload();
    //     }
        
        
    // }

    void reload()
    {
        Debug.Log("reload start: " + Time.time);
        float elapsedTime = 0;
        if (elapsedTime < reloadTime)
        {
            elapsedTime += Time.deltaTime;
        }
        else isLoaded = true;
        Debug.Log("reload done: " + Time.time);
    }


    public void aim(Vector3 target) 
    {
        Debug.DrawLine(transform.position, target, Color.yellow);
        transform.LookAt(target);
    }

    GameObject getBullet() => Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);

    // void updateDeerInRange()
    // {
    //     foreach (Deer deer in GameObject.Find("deer").transform)
    //     {
    //         if (distance)
    //     }
    // }
}
