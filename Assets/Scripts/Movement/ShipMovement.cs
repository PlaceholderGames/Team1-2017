using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles probe movement and slipstreams gravity application
/// </summary>
public class ShipMovement : MonoBehaviour
{
    /// <summary>
    /// Normal move speed
    /// </summary>
    public float moveSpeed = 10000; 

    /// <summary>
    /// Warped speed
    /// </summary>
    public float superSpeed = 10000;

    /// <summary>
    /// Fuel consumption rate for normal move speed
    /// </summary>
    public float normalFuelRate = 1f; 

    /// <summary>
    /// Fuel consumption rate for warped speed
    /// </summary>
    public float superFuelRate = 2.5f; 

    /// <summary>
    /// Reference to probe's engine lens flare
    /// </summary>
    public GameObject lensflare;

    /// <summary>
    /// Reference to probe's engine particle system
    /// </summary>
    public GameObject particles;

    /// <summary>
    /// Reference to speedometer object
    /// </summary>
    public GameObject speedometer;

    /// <summary>
    /// Reference to fuelcounter object
    /// </summary>
    public GameObject fuelcounter;

    /// <summary>
    /// Previous speed the probe was at
    /// </summary>
    private float previousSpeed = 0f;

    /// <summary>
    /// Local reference of probe's variable object
    /// </summary>
    private ProbeObject probe;

    /// <summary>
    /// Local reference of probe's rigidbody
    /// </summary>
    private Rigidbody rb;
    
    /// <summary>
    /// Difference in spatial position between ship and camera chasing it
    /// </summary>
    [SerializeField]
    private Vector3 cameraOffset = new Vector3(0, 1.25f, -4);


    void Start()
    {
        probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        rb.position = GlobalObject.Instance.Position;
    }

    void FixedUpdate()
    {
        //purpose: conducts probe movement if certain key(s) are pressed

        if (probe.GetFuel() > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W)) //if both keys W and LShift are held
            {
                //apply additional force in direction of local Z axis
                rb.AddRelativeForce(0, 0, superSpeed * Time.deltaTime, ForceMode.Acceleration);

                //update fuel
                probe.SetFuel(probe.GetFuel() - superFuelRate);

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 1f;
                particles.GetComponent<ParticleSystem>().Play();
            }
            else if (Input.GetKey(KeyCode.S)) //if key S is held
            {
                if (previousSpeed > probe.GetCurrentSpeed()) //slow down whilst speed is decreasing
                {
                    //slow down probe
                    rb.AddRelativeForce(0, 0, -moveSpeed * Time.deltaTime, ForceMode.Acceleration);

                    //update fuel
                    probe.SetFuel(probe.GetFuel() - superFuelRate);

                    //disable engine effects
                    lensflare.GetComponent<LensFlare>().brightness = 0f;
                    particles.GetComponent<ParticleSystem>().Stop();
                }
            }
            else if (Input.GetKey(KeyCode.Q)) //if key Q is held
            {
                //bring probe to a stop
                rb.velocity = new Vector3(0, 0, 0);

                //disable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 0f;
                particles.GetComponent<ParticleSystem>().Stop();
            }
            else if (Input.GetKey(KeyCode.W)) //if key W is held
            {
                //apply force in positive direction of local Z axis
                rb.AddRelativeForce(0, 0, moveSpeed * Time.deltaTime, ForceMode.Acceleration);

                //update fuel
                probe.SetFuel(probe.GetFuel() - normalFuelRate);

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 0.75f;
                particles.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                //disable all engine effects
                lensflare.GetComponent<LensFlare>().brightness = 0;
                particles.GetComponent<ParticleSystem>().Stop();
            }
        }
        else
        {
            //disable all engine effects
            lensflare.GetComponent<LensFlare>().brightness = 0;
            particles.GetComponent<ParticleSystem>().Stop();
        }

        //manage fuel tasks
        if (fuelcounter != null)
        {
            fuelcounter.GetComponent<Text>().text = "Fuel: " + probe.GetFuelRounded().ToString();
        }

        //manage speed tasks
        if (speedometer != null)
        {
            speedometer.GetComponent<Text>().text = "Speed: " + probe.GetCurrentSpeed().ToString() + " KP/H";
        }

        //store current speed to check in the next FixedUpdate call so that the script can ensure the slowdown function doesn't reverse the probe
        previousSpeed = probe.GetCurrentSpeed();

        MoveCamera();
    }
    
    /// <summary>
    /// Allows the camera to chase the ship at all times
    /// </summary>
    void MoveCamera() { transform.GetChild(0).localPosition = cameraOffset; }
}