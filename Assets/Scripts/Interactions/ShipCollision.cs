/*
    purpose: handles the damage calculation and effects generation when a ship collides with another object
    usage: attached to solar ships, moving space stations, and the player probes
*/

using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public float damageSensitivity = 1000f;
    public GameObject[] explosions; //contains prefabs of explosion effects this object will need for its explosion
    private float countdown = 0f;


    void Update()
    {
        if (countdown >= 0.0f) countdown -= Time.deltaTime;
    }
    
    void OnCollisionStay(Collision collision)
    {
        if (countdown <= 0f)
        {
            //get local references of collided objects
            GeneralVariables objThem = collision.collider.GetComponent<GeneralVariables>();
            GeneralVariables objThis = GetComponent<GeneralVariables>();

            //calculate and apply damage to both objects
            float dmgInflicted = 0;
            if (objThis.GetComponent<ProbeVariables>()) dmgInflicted = CalculateDamage(objThis.GetMass(), objThis.GetCurrentSpeed(), objThem.GetMass());
            else dmgInflicted = CalculateDamage(objThis.GetMass(), 0, objThem.GetMass());
            objThem.Health -= dmgInflicted;
            objThis.Health -= dmgInflicted;

            //check for deaths
            if (objThem.Health <= 0) Destroy(objThem.gameObject);
            if (objThis.Health <= 0)
            {
                Destroy(objThis.gameObject);
                foreach (ContactPoint contact in collision.contacts)
                {
                    for (int i = 0; i < 5; i++) //create five different explosions
                    {
                        GameObject newExplosion = Instantiate(explosions[Random.Range(0, explosions.Length)], contact.point, new Quaternion(0f, 0f, 0f, 0f));
                        newExplosion.GetComponent<ParticleSystem>().Play();

                    }
                }
            }

            //reset countdowns
            if (!objThem.GetComponent<BodyVariables>()) countdown = 100.0f;
        }
    }

    private float CalculateDamage(float thisMass, float thisSpeed, float themMass) { return (thisMass + thisSpeed) * (themMass / damageSensitivity); }
}