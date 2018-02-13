/*
    purpose: variables class for projectiles/missiles/torpedoes
    usage: only used on projectile/missile/torpedo entities
*/

using UnityEngine;

public class ProjectileObject : GeneralObject
{
    //projectile capability stats
    public float Fuel = 1000f; //controls distance that the projectile traverse
    public float DamageOutput = 10000f; //damage output when colliding
    public float ForceForSpeed = 10000f; //force required to push it to its maximum speed
}