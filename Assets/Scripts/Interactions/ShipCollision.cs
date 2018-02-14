/*
    purpose: handles the damage calculation and effects generation when a ship collides with another object
    usage: attached to solar ships, moving space stations, and the player probes
*/

using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public float damageAdjust = 1000f;
    private float countdown = 0f;

    void Update()
    {
        if (countdown >= 0.0f) countdown -= Time.deltaTime;
    }
    
    void OnCollisionStay(Collision collision)
    {
        if (countdown <= 0f && !collision.collider.GetComponent<ProjectileObject>())
        {
            //get local references of collided objects
            GeneralObject objThem = collision.collider.GetComponent<GeneralObject>();
            GeneralObject objThis = GetComponent<GeneralObject>();

            //calculate and apply damage to both objects
            float dmgInflicted = 0;
            if (objThis.GetComponent<ProbeObject>()) dmgInflicted = CalculateDamage(objThis.GetMass(), objThis.GetCurrentSpeed(), objThem.GetMass());
            else dmgInflicted = CalculateDamage(objThis.GetMass(), 0, objThem.GetMass());
            objThem.Health -= dmgInflicted;
            objThis.Health -= dmgInflicted;

            //reset countdowns
            if (!objThem.GetComponent<BodyObject>()) countdown = 100.0f;
        }
    }

    private float CalculateDamage(float thisMass, float thisSpeed, float themMass) { return (thisMass + thisSpeed) * (themMass / damageAdjust); }
}