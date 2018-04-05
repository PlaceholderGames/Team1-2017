using UnityEngine;

/// <summary>
/// Handles the damage calculation and effects generation when a ship collides with another object
/// </summary>
public class ShipCollision : MonoBehaviour
{
    /// <summary>
    /// User-specified factor to alter calculations with
    /// </summary>
    public float damageAdjust = 1000f;

    /// <summary>
    /// Countdown to prevent constant damage calculations that result in insta-death
    /// </summary>
    private float countdown = 0f;

    void Update() { if (countdown >= 0.0f) countdown -= Time.deltaTime; }
    
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Projectile")) return;

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

    /// <summary>
    /// Calculates a damage value with given parametres
    /// </summary>
    /// <param name="thisMass">Your mass</param>
    /// <param name="thisSpeed">Your speed at time of impact</param>
    /// <param name="themMass">Their mass</param>
    /// <returns>Returns float as the damage calculation result</returns>
    private float CalculateDamage(float thisMass, float thisSpeed, float themMass) { return (thisMass + thisSpeed) * (themMass / damageAdjust); }
}