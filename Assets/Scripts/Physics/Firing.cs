using UnityEngine;

/// <summary>
/// Enables a playable object to fire a weapon
/// </summary>
class Firing : MonoBehaviour
{
    /// <summary>
    /// Reference to a prefab of the weapon to be fired
    /// </summary>
    [SerializeField]
    private GameObject projectile = null;

    /// <summary>
    /// Desired cooldown between firing to prevent weapon from being rapid-fired (if needed)
    /// </summary>
    [SerializeField]
    private float CooldownTime = 0.1f;

    /// <summary>
    /// Internal cooldown timer variable
    /// </summary>
    private float Cooldown = 0f;

    /// <summary>
    /// Local reference to probe object class
    /// </summary>
    private ProbeObject probe;

    void Start() { probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>(); }

    void FixedUpdate()
    {
        Cooldown -= Time.deltaTime; //decrement cooldown each FixedUpdate

        if (probe.GetFuelRounded() > 0 && Cooldown <= 0f) //only fire if fuel and cooldown allow
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
                newProjectile.GetComponent<ProjectileObject>().ParentSpeed = probe.GetCurrentSpeed();
                probe.SetFuel(probe.GetFuel() - Random.Range(1f, 100f));
            }
            Cooldown = CooldownTime; //enable cooldown on firing
        }
    }
}