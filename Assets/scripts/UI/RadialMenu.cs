using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialMenu : MonoBehaviour
{
    public static RadialMenu instance { get; private set; }
    [SerializeField] GameObject deerPrefab, wolfPrefab;
    [SerializeField] Button spawnDeer, spawnWolf, addLog, takeDamageButton, eatButton, drinkButton, addToBoilerButton;
    
    bool isGhosting;
    GameObject heldObject;

    void Awake() => instance = this;
    void Start()
    {
        spawnDeer.onClick.AddListener(() => ghostDeer());
        spawnDeer.onClick.AddListener(() => ghostWolf());
        addLog.onClick.AddListener(() => addLogToFire());
        takeDamageButton.onClick.AddListener(() => takeDamage());
        eatButton.onClick.AddListener(() => eatSomething());
        drinkButton.onClick.AddListener(() => drink());
        addToBoilerButton.onClick.AddListener(() => addWaterToBoiler());
        close();
    }

    void drink() 
    {
        close();
        if (Inventory.instance.unitsOfWater > 0)
        {
            Inventory.instance.unitsOfWater --;
            FindObjectOfType<Thirst>().waterLevel += 10;
        }
    }

    void addWaterToBoiler()
    {
        close();
        BoilerStateManager boiler = FindObjectOfType<BoilerStateManager>();
        boiler.switchState(boiler.dirty);
    }

    void addLogToFire()
    {
        close();
        Fire.instance.add();
    }

    void eatSomething()
    {
        close();
        Inventory.instance.getLeastPerishableFood();
    }

    void takeDamage()
    {
        close();
        Survivor.instance.GetComponent<Health>().decrease(10);
    }

    
    void placeObject()
    {
        close();
        Debug.Log("object placed");
        heldObject = null;
        isGhosting = false;
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
        CameraController.instance.freeMouseLook();
    }
}
