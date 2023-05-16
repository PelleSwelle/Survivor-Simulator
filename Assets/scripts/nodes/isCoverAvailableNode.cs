using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCoverAvailableNode : Node
{
    private Cover[] availableCovers;
    private Transform target;
    private EnemyAI ai;

    public isCoverAvailableNode(Cover[] availableCovers, Transform target, EnemyAI ai)
    {
        this.availableCovers = availableCovers;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform bestSpot = findBestCoverSpot();
        ai.setBestCoverSpot(bestSpot);
        return bestSpot != null ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private Transform findBestCoverSpot()
    {
        float minAngle = 90;
        Transform bestSpot = null;

        for (int i = 0; i < availableCovers.Length; i++)
        {
            Transform bestSpotInCover = findBestSpotInCover(availableCovers[i], ref minAngle);
            if (bestSpotInCover != null)
            {
                bestSpot = bestSpotInCover;
            }
        }
        return bestSpot;
    }

    private Transform findBestSpotInCover(Cover cover, ref float minAngle)
    {
        Transform[] availableSpots = cover.getCoverSpots();
        Transform bestSpot = null;

        for (int i = 0; i < availableCovers.Length; i++)
        {
            Vector3 direction = target.position - availableSpots[i].position;
            if (checkIfSpotIsValid(availableSpots[i]))
            {
                float angle = Vector3.Angle(availableSpots[i].forward, direction);
                {
                    if (angle < minAngle)
                    {
                        minAngle = angle;
                        bestSpot = availableSpots[i]; 
                    }
                }
            }
        }
        return bestSpot;
    }

    private bool checkIfSpotIsValid(Transform spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - spot.position;
        
        if (Physics.Raycast(spot.position, direction, out hit))
        {
            if (hit.collider.transform != target)
            {
                return true; 
            }
        }
        return false;
    }
}
