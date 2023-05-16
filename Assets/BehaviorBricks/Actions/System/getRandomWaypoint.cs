using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;

namespace BBUnity.Actions
{
    [Action("getRandomWaypoint")]
    public class getRandomWaypoint : GOAction
    {
        [OutParam("waypoint")] Vector3 waypoint;
        public override void OnStart()
        {
            GameObject[] waypoints = GameObject.FindGameObjectsWithTag("deerWayPoint");
            int i = Random.Range(0, waypoints.Length);
            waypoint = waypoints[i].transform.position;
        }
    }
}
