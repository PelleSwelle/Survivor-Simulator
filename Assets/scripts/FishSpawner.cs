using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] Transform lake;
    [SerializeField] Fish[] fish;

    [SerializeField] int desiredAmountInLake;

    int currentAmountInLake;

    void Update()
    {
        if (currentAmountInLake < desiredAmountInLake)
            spawnFish();
    }

    void spawnFish()
    {
        int seed = Random.Range(0, fish.Length);
        float randomX = Random.Range(lake.position.x, 200);
        float randomZ = Random.Range(lake.position.z, 200);

        Fish newFish = Instantiate(fish[seed], new Vector3(randomX, transform.position.y, randomZ), Quaternion.identity, transform);
        newFish.lake = lake;
        currentAmountInLake ++;
    }
}
