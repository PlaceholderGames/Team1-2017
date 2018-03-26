/*
    purpose: enables a playable object to fire missiles
    usage: probes only
*/

using UnityEngine;

namespace Assets.Scripts.Offence
{
    class Firing : MonoBehaviour
    {
        public GameObject projectile = null; //prefab of projectile
        private float Cooldown = 0f; //cooldown to prevent missiles from being continously rapid-fired
        public float CooldownTime = 1f; //stores desired cooldown time
        private ProbeObject probe; //internal reference for the probe object

        void Start()
        {
            probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
        }

        void FixedUpdate()
        {
            Cooldown -= Time.deltaTime; //decrement cooldown each FixedUpdate

            if (probe.GetMunitionsRemaining() > 0 && Cooldown <= 0f) //only fire if munitions count and cooldown allow
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
                    newProjectile.GetComponent<ProjectileObject>().ParentSpeed = probe.GetCurrentSpeed();
                    probe.SetMunitionsRemaining(probe.GetMunitionsRemaining() - 1);
                }
                Cooldown = CooldownTime; //enable cooldown on firing
            }
        }
    }
}