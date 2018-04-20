
/*
    purpose: handles probe movement and gravity application
    usage: attached to probe
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10000; //normal move speed
    public float superSpeed = 10000; //warped speed
    public float normalFuelRate = 1f; //fuel consumption rate for normal move speed
    public float superFuelRate = 2.5f; //fuel consumption rate for warped speed
    public GameObject lensflare; //reference to lens flare
    public GameObject particles; //reference to particles
    public GameObject speedometer; //reference to speedometer object
    public GameObject fuelcounter; //reference to fuelcounter object
    private float previousSpeed = 0f;
    private Rigidbody rb;
    private float fuel = 100;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //purpose: conducts probe movement if certain key(s) are pressed

        if (Input.GetKey(KeyCode.Escape)) SceneManager.LoadScene(1);

        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W)) //if both keys W and LShift are held
            {
                //apply additional force in direction of local Z axis
                rb.AddRelativeForce(0, superSpeed * Time.deltaTime, 0, ForceMode.Acceleration);

                //update fuel
                fuel -= superFuelRate;

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 1f;
                particles.GetComponent<ParticleSystem>().Play();
            }
            else if (Input.GetKey(KeyCode.S)) //if key S is held
            {
                    //slow down probe
                    rb.AddRelativeForce(0, -moveSpeed * Time.deltaTime,0, ForceMode.Acceleration);

                    //update fuel
                    fuel -= superFuelRate;

                    //disable engine effects
                    lensflare.GetComponent<LensFlare>().brightness = 0f;
                    particles.GetComponent<ParticleSystem>().Stop();
                
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
                rb.AddRelativeForce(0, moveSpeed * Time.deltaTime, 0, ForceMode.Acceleration);

                //update fuel
                fuel -= normalFuelRate;

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
    }
}
