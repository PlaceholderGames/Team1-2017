using UnityEngine;

/// <summary>
/// Gravity physics ("Gravimetres") engine
/// </summary>
public class Gravimetrics : MonoBehaviour
{
    /// <summary>
    /// Gravitational constant of the universe
    /// </summary>
    private const float G = 0.667408f;

    /// <summary>
    /// Container of all planetary bodies
    /// </summary>
    private BodyObject[] Bodies; 

    void Start()
    {
        //populate Bodies array with all planets
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //get local reference to all planets
        Bodies = new BodyObject[planets.Length]; //initialise Bodies array
        for (int i = 0; i < planets.Length; i++) Bodies[i] = planets[i].GetComponent<BodyObject>();
    }

    void FixedUpdate()
    {
        //apply gravimetric effect to object from all bodies
        GravimetricResult currentGrav = new GravimetricResult(new Vector3(0, 0, 0), 0);
        if (GetComponent<Atmospherics>()) GetComponent<Atmospherics>().ResetDrag(); //reset drag so new calculation can be used
        for (int i = 0; i < Bodies.Length; i++)
        {
            if (Bodies[i])
            {
                currentGrav = GetGravity(Bodies[i]); //get gravity calculation result
                GetComponent<Rigidbody>().AddRelativeForce(currentGrav.GetForce()); //apply gravimetric force
                if (GetComponent<Atmospherics>()) GetComponent<Atmospherics>().ApplyDragDueToGravity(currentGrav); //call for atmospheric drag to be applied
            }
        }
    }

    /// <summary>
    /// Calculates a gravimetric result optimised for when the probe is moving
    /// </summary>
    /// <param name="body">Body to calculate gravity with</param>
    /// <returns>Returns a GravimetricResult object containing the data used/resulting by/from the gravity calculation</returns>
    public GravimetricResult GetGravity(BodyObject body)
    {
        Vector3 direction = body.GetPosition() - GetComponent<GeneralObject>().GetPosition(); //work out direction between both objects
        float distance = direction.magnitude; //get distance from direction
        float magnitude = G * ((body.GetMass() * GetComponent<GeneralObject>().GetMass()) / Mathf.Pow(distance, 2)); //calculates the magnitude of the gravitational force
        Vector3 force = direction.normalized * (magnitude * body.GravimetricStrength); //convert calculation into workable force
        return new GravimetricResult(force, distance);
    } 
}