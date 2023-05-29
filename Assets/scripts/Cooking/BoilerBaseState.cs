using UnityEngine;

public abstract class BoilerBaseState
{
    public abstract void EnterState(BoilerStateManager boiler);
    public abstract void UpdateState(BoilerStateManager boiler);
    public abstract void OnCollisionEnter(BoilerStateManager boiler, Collision collision);
    
    public void setMaterial(BoilerStateManager boiler, Material material)
    {
        GameObject water = boiler.transform.GetChild(1).gameObject;
        water.GetComponent<MeshRenderer>().material = material;
    }
}
