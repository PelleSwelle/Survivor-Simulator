using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    public static RadialMenu instance { get; private set; }
    [SerializeField] GameObject deerPrefab, wolfPrefab;
    [SerializeField] Button showDirectionsButton, spawnDeer, spawnWolf, addLog, takeDamageButton, eatButton, drinkButton;
    bool isGhosting;
    GameObject heldObject;

    void Awake() => instance = this;
    void Start()
    {
        spawnDeer.onClick.AddListener(() => ghostDeer());
        spawnDeer.onClick.AddListener(() => ghostWolf());
        addLog.onClick.AddListener(() => addLogToFire());
        showDirectionsButton.onClick.AddListener(() => showDirections());
        takeDamageButton.onClick.AddListener(() => takeDamage());
        eatButton.onClick.AddListener(() => eatRation());
        drinkButton.onClick.AddListener(() => drink());
        close();
    }

    void drink() => FindObjectOfType<Thirst>().waterLevel += 10;

    void addLogToFire()
    {
        close();
        Fire.instance.add();
    }

    void eatRation()
    {
        close();
        FindObjectOfType<Hunger>().eat(new Ration());
    }

    void takeDamage()
    {
        close();
        FindObjectOfType<Health>().decrease(10);
    }

    
    void placeObject()
    {
        Debug.Log("object placed");
        heldObject = null;
        isGhosting = false;
    }

    void showDirections()
    {
        close();
        foreach(DirectionVisualizer visualizer in GameObject.FindObjectsOfType<DirectionVisualizer>())
            visualizer.toggle();
    }

    void ghostDeer()
    {
        close();
        throw new System.NotImplementedException();
        // isGhosting = true;
        
        // RaycastHit hit;
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        // {
        //     heldObject = Instantiate(deerPrefab, hit.point, Quaternion.identity);
        // }
    }
    void ghostWolf()
    {
        close();
        throw new System.NotImplementedException();
        // isGhosting = true;
        
        // RaycastHit hit;
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        // {
        //     heldObject = Instantiate(deerPrefab, hit.point, Quaternion.identity);
        // }
    }

    void setDeerToMousePosition(Vector3 position)
    {
        GameObject deer = Instantiate(deerPrefab, position, Quaternion.identity, GameObject.Find("deerParent").transform);
    }

    public void open()
    {
        gameObject.SetActive(true);
        CameraController.instance.disableMouseLook();
    }
    public void close()
    {
        gameObject.SetActive(false);
        CameraController.instance.enableMouseLook();
    }
}
