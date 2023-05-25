    using UnityEngine;
 
    using Pada1.BBCore;           // Code attributes
    using Pada1.BBCore.Tasks;     // TaskStatus
    using Pada1.BBCore.Framework; // BasePrimitiveAction
 
    [Action("survival/ShootOnce")]
    public class ShootOnce : BasePrimitiveAction
    {
        [InParam("shootPoint")] public Transform shootPoint;
        [InParam("bullet")] public GameObject bullet;
        [InParam("velocity", DefaultValue = 30f)] public float velocity;
       
        public override TaskStatus OnUpdate()
        {
            bool hasAmmo = Survivor.instance.ammo > 0;
            if (hasAmmo)
            {
                GameObject newBullet = GameObject.Instantiate(
                    bullet, shootPoint.position,
                    shootPoint.rotation * bullet.transform.rotation
                    ) as GameObject;

                if (newBullet.GetComponent<Rigidbody>() == null)
                    newBullet.AddComponent<Rigidbody>();
    
                newBullet.GetComponent<Rigidbody>().velocity = velocity * shootPoint.forward;
                Survivor.instance.GetComponent<AudioSource>().Play();
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.FAILED;
        }
    }