using UnityEngine;

namespace Assets.Scripts.Offence
{
    class Firing : MonoBehaviour
    {
        public GameObject projectile = null; //prefab of projectile
        private float Countdown = 0f;

        void FixedUpdate()
        {
            Countdown -= Time.deltaTime;

            ProbeObject probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();

            if (probe.GetMunitionsRemaining() > 0 && Countdown <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Quaternion FiringRotation = transform.rotation;
                    Vector3 FiringPositon = new Vector3(transform.position.x + FiringRotation.x, transform.position.y + FiringRotation.y - 2f, transform.position.z + FiringRotation.z - 2f);
                    
                    //Quaternion FiringRotation = probe.GetRotation();
                    GameObject newProjectile = Instantiate(projectile, FiringPositon, FiringRotation);
                    newProjectile.GetComponent<ProjectileObject>().ParentSpeed = probe.GetCurrentSpeed();
                    probe.SetMunitionsRemaining(probe.GetMunitionsRemaining() - 1);
                }
                Countdown = 0.5f;
            }
        }
    }
}