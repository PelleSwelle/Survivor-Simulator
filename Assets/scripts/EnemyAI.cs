using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthThreshold;
    [SerializeField] private float healthRestoreRate;
    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Cover[] availableCovers;
    private Material material;
    private Transform bestCoverSpot;

    private Node topNode;

    public void setColor(Color color)
    {
        material.color = color;
    }

    public Transform getBestCoverSpot()
    {
        return bestCoverSpot;
    }
    private float currentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }
    private void Start()
    {
        currentHealth = startingHealth;
        material = GetComponent<MeshRenderer>().material;

        constructBehaviorTree();
    }

    private void constructBehaviorTree()
    { 
        isCoverAvailableNode coverAvailableNode = new isCoverAvailableNode(availableCovers, playerTransform, this);
        // GoToCoverNode goToCoverNode = new GoToCoverNode()
        // reached 26:20 in https://www.youtube.com/watch?v=F-3nxJ2ANXg    
    }

    public void setBestCoverSpot(Transform bestCoverSpot)
    {
        this.bestCoverSpot = bestCoverSpot;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    private void Update()
    {
        currentHealth += Time.deltaTime * healthRestoreRate;
    }
}
