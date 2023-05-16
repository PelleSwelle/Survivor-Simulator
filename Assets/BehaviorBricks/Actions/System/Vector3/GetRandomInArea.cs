﻿using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to obtain a random position of an area.
    /// </summary>
    [Action("Vector3/GetRandomInArea")]
    [Help("Gets a random position from a given area")]
    public class GetRandomInArea : GOAction
    {
        /// <summary>The Name property represents the GameObject Input Parameter that must have a BoxCollider or SphereColider.</summary>
        /// <value>The Name property gets/sets the value of the GameObject field, area.</value>
        [InParam("area")]
        [Help("GameObject that must have a BoxCollider or SphereColider, which will determine the area from which the position is extracted")]
        public GameObject area { get; set; }

        /// <summary>The Name property represents the Output Position randomly parameter taken from the area Parameter.</summary>
        /// <value>The Name property gets/sets the value of the Vector3 field, randomPosition.</value>
        [OutParam("randomPosition")]
        [Help("Position randomly taken from the area")]
        public Vector3 randomPosition { get; set; }

        /// <summary>Initialization Method of GetRandomInArea</summary>
        /// <remarks>Verify if there is an area, showing an error if it does not exist. Check that the area is a box or sphere to differentiate the
        /// calculations when obtaining the random position of those areas. Once differentiated, you get the limits of the area to calculate a
        /// random position.</remarks>
        public override void OnStart()
        {
            if (area == null)
            {
                Debug.LogError("The area of moving is null", gameObject);
                return;
            }

            BoxCollider boxCollider = area.GetComponent<BoxCollider>();
            SphereCollider sphereCollider = area.GetComponent<SphereCollider>();
            if (boxCollider != null)
                randomPosition = getRandomPointOnBoxCollider(boxCollider);
            else if (sphereCollider != null)
                randomPosition = getRandomPointOnSphereCollider(sphereCollider);
            else
            {
                Debug.LogError("The " + area + " GameObject must have a Box, Sphere or Terrain Collider component", gameObject);
            }
        }

        Vector3 getRandomPointOnSphereCollider(SphereCollider sphereCollider)
        {
            float distance = UnityEngine.Random.Range(-sphereCollider.radius, area.transform.localScale.x * sphereCollider.radius);
            float angle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
            return new Vector3(
                area.transform.position.x + distance * Mathf.Cos(angle),
                area.transform.position.y,
                area.transform.position.z + distance * Mathf.Sin(angle));
        }

        Vector3 getRandomPointOnBoxCollider(BoxCollider boxCollider)
        {
            float randomX = Random.Range(
                    area.transform.position.x - area.transform.localScale.x * boxCollider.size.x * 0.5f, 
                    area.transform.position.x + area.transform.localScale.x * boxCollider.size.x * 0.5f
                );
            float randomZ = Random.Range(
                    area.transform.position.z - area.transform.localScale.z * boxCollider.size.z * 0.5f,
                    area.transform.position.z + area.transform.localScale.z * boxCollider.size.z * 0.5f);
            return new Vector3(
                randomX,
                area.transform.position.y,
                randomZ);
        }

        public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;
    }
}
