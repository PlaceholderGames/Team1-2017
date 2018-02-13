/*
    purpose: pushes projectile/missile/torpedo when it is launched
    usage: projectile/missile/torpedo
*/

using UnityEngine;

namespace Assets.Scripts.Movement
{
    class ProjectilePush : MonoBehaviour
    {
		public float Consumption = 1.5f; //rate of which the projectile consumes fuel

        void FixedUpdate()
        {
			if (GetComponent<ProjectileObject>().Fuel > 0) //travel only if fuel is available
			{
				GetComponent<Rigidbody>().AddRelativeForce(0, 0, GetComponent<ProjectileObject>().ForceForSpeed * Time.deltaTime, ForceMode.Acceleration); //push projectile with relative force 
                GetComponent<ProjectileObject>().Fuel -= Consumption;
			}
			else Destroy(gameObject);
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