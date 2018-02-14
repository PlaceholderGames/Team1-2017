/*
    purpose: pushes projectile/missile/torpedo when it is launched
    usage: projectile/missile/torpedo
*/

using UnityEngine;

namespace Assets.Scripts.Movement
{
    class ProjectilePush : MonoBehaviour
    {
        //public GameObject lens = null;
        //public GameObject particles = null;
        public float Consumption = 1.5f; //rate of which the projectile consumes fuel
        //private float UntilIgnition = 0.25f; 

        void Start()
        {
            //lens.GetComponent<LensFlare>().enabled = false;
            //particles.GetComponent<ParticleSystem>().Pause();
        }

        void FixedUpdate()
        {
           // UntilIgnition -= Time.deltaTime;
            //if (UntilIgnition <= 0)
            //{
            //    lens.GetComponent<LensFlare>().enabled = true;
            //    particles.GetComponent<ParticleSystem>().Play();
           // }

            GetComponent<Rigidbody>().AddRelativeForce(0, 0, (GetComponent<ProjectileObject>().ForceForSpeed + GetComponent<ProjectileObject>().ParentSpeed) * Time.deltaTime, ForceMode.Acceleration); //push projectile with relative force 
            GetComponent<ProjectileObject>().Fuel -= Consumption;
        }

        void OnCollisionEnter(Collision collision)
        {
            //get local references of collided objects
            GeneralObject objThem = collision.collider.GetComponent<GeneralObject>();
            ProjectileObject objThis = GetComponent<ProjectileObject>();

            //inflict damage to them upon hit
            objThem.Health -= Random.Range(0, objThis.DamageOutput);

            //destroy missile itself
            objThis.Explode(true);

        }
    }
}