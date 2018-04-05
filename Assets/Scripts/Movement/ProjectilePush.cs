using UnityEngine;

/// <summary>
/// Pushes projectile/missile/torpedo when it is launched
/// </summary>
class ProjectilePush : MonoBehaviour
{
    /// <summary>
    /// Projectile's fuel consumption rate
    /// </summary>
    public float Consumption = 1.5f; 

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * GetComponent<ProjectileObject>().ForceForSpeed);
        GetComponent<ProjectileObject>().Fuel -= Consumption;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player")) return;

        //get local references of collided objects
        GeneralObject objThem = collision.collider.GetComponent<GeneralObject>();
        ProjectileObject objThis = GetComponent<ProjectileObject>();

        //calculate damage inflicted
        float damage = Random.Range(0, objThis.DamageOutput);

        //inflict damage to them upon hit

        if (objThem.GetPopulation() > 0) //if population exists, kill population before damaging object itself
        {
            if (objThem.GetPopulation() - damage > 0) objThem.SetPopulation(objThem.GetPopulation() - (int)damage); //all damage to population if population remains above 0
            else
            {
                //kill entire population and inflict remainder damage on object iself
                damage -= (damage - objThem.GetPopulation());
                objThem.SetPopulation(0);
                objThem.Health -= damage;
            }
        }
        else objThem.Health -= Random.Range(0, objThis.DamageOutput);

        //destroy missile itself
        objThis.Explode(true);
    }
}