/*
    purpose: handles probe movement and gravity application
    usage: attached to probe
*/

using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 10000; //normal move speed
    public float reverseSpeed = 1000; //normal move speed
    public float superSpeed = 10000; //warped speed
    public float teleportSpeed = 0; //teleport distance
    public float normalFuelRate = 1; //fuel consumption rate for normal move speed
    public float superFuelRate = 2.5f; //fuel consumption rate for warped speed
    public GameObject lensflare; //reference to lens flare
    public GameObject particles; //reference to particles
    public GameObject speedometer; //reference to speedometer object
    public GameObject fuelcounter; //reference to fuelcounter object

    void FixedUpdate()
    {
        //purpose: conducts probe movement if certain key(s) are pressed

        if (GetComponent<ProbeVariables>().GetFuel() > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W)) //if both keys W and LShift are held
            {
                //apply additional force in direction of local Z axis
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, superSpeed * Time.deltaTime, ForceMode.Force);

                //update fuel
                GetComponent<ProbeVariables>().SetFuel(GetComponent<ProbeVariables>().GetFuel() - superFuelRate);

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 1.5f;
                particles.GetComponent<ParticleSystem>().Play();
            }
            else if (Input.GetKey(KeyCode.S)) //if key S is held
            {
                //slow down probe
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, -reverseSpeed * Time.deltaTime, ForceMode.Force);

                //update fuel
                GetComponent<ProbeVariables>().SetFuel(GetComponent<ProbeVariables>().GetFuel() - superFuelRate);

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 0f;
                particles.GetComponent<ParticleSystem>().Stop();
            }
            else if (Input.GetKey(KeyCode.Q)) //if key S is held
            {
                //bring probe to a stop
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 0f;
                particles.GetComponent<ParticleSystem>().Stop();
            }
            else if (Input.GetKey(KeyCode.W)) //if key W is held
            {
                //apply force in positive direction of local Z axis
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, moveSpeed * Time.deltaTime, ForceMode.Force);

                //update fuel
                GetComponent<ProbeVariables>().SetFuel(GetComponent<ProbeVariables>().GetFuel() - normalFuelRate);

                //enable engine effects
                lensflare.GetComponent<LensFlare>().brightness = 1f;
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

        //if (Input.GetKeyDown(KeyCode.Space)) //if and when key Space is pressed
        //{
        //    //apply a big amount of force in direction of local Z axis
        //    GetComponent<Rigidbody>().AddRelativeForce(0, 0, teleportSpeed, ForceMode.Force);
        //}

        //manage fuel tasks
        if (fuelcounter != null)
        {
            fuelcounter.GetComponent<Text>().text = "Fuel: " + GetComponent<ProbeVariables>().GetFuelRounded().ToString();
        }

        //manage speed tasks
        if (speedometer != null)
        {
            speedometer.GetComponent<Text>().text = "Speed: " + GetComponent<ProbeVariables>().GetCurrentSpeed().ToString() + " KP/H";
        }
    }
}