using UnityEngine;

namespace Assets.Scripts.Offence
{
    class Firing : MonoBehaviour
    {
        public GameObject projectile = null; //prefab of projectile
        private float Countdown = 0f;
        private ProbeObject probe;

        void Start()
        {
            probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
        }

        void FixedUpdate()
        {
            Countdown -= Time.deltaTime;

            if (probe.GetMunitionsRemaining() > 0 && Countdown <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
                    newProjectile.GetComponent<ProjectileObject>().ParentSpeed = probe.GetCurrentSpeed();
                    probe.SetMunitionsRemaining(probe.GetMunitionsRemaining() - 1);
                }
                Countdown = 0.5f;
            }
        }
    }
}