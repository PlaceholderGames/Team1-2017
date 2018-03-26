using UnityEngine;

/// <summary>
/// Atmosphere physics ("Atmospherics") engine
/// </summary>
public class Atmospherics : MonoBehaviour
{
    /// <summary>
    /// Base unit for calculating relative drag with
    /// </summary>
    public float AtmosphericUnit = 0.25f;

    /// <summary>
    /// Used for converting distance values into a scaled-down decimals
    /// </summary>
    public float ScaleFactor = 100000;

    /// <summary>
    /// Declares how close the object has to be for burning up
    /// </summary>
    public float InteractivityRange = 100;

    /// <summary>
    /// Reference to particle system responsible for burning effect
    /// </summary>
    public GameObject particles;

    /// <summary>
    /// Container of all planetary bodies
    /// </summary>
    private BodyObject[] Bodies;

    /// <summary>
    /// Array of flags that indicate what body the planet is within range of
    /// </summary>
    private bool[] isInRange; 

    void Start()
    {
        //populate Bodies array with all planets
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //get local reference to all planets
        Bodies = new BodyObject[planets.Length]; //initialise Bodies array
        for (int i = 0; i < planets.Length; i++) Bodies[i] = planets[i].GetComponent<BodyObject>();

        //initialise bool for in range 
        isInRange = new bool[Bodies.Length];
    }

    void FixedUpdate()
    {
        //check what bodies the object is within range of
        for (int i = 0; i < Bodies.Length; i++) isInRange[i] = checkInRange(Bodies[i]);

        //attempt to apply burning effect if applicable
        attemptBurn();
    }

    /// <summary>
    /// Searches through isInRange array to see if burning effect should be applied
    /// </summary>
    private void attemptBurn()
    {
        for (int i = 0; i < isInRange.Length; i++)
        {
            if (isInRange[i])
            {
                //object in range; enable effect and get out of method
                particles.GetComponent<ParticleSystem>().Play();
                return;
            }
        }

        //if code gets here, object not in range; disable effect and continue normally
        particles.GetComponent<ParticleSystem>().Stop();
    }

    /// <summary>
    /// Shecks if the object is in range of the passed through planetary body
    /// </summary>
    /// <param name="obj">Body's BodyObject for getting planetary data from</param>
    /// <returns>Returns a boolean that indicates if a body is within range</returns>
    public bool checkInRange(BodyObject obj)
    {
        //throw if BodyObjects refers to a destroyed object
        if (!obj) return false;

        //calculate relative distance between object and body
        Vector3 direction = obj.GetPosition() - GetComponent<ProbeObject>().GetPosition();
        float distance = direction.magnitude;

        //check if object and body are within range
        if (distance < obj.GetSize() + InteractivityRange) return true;
        else return false;
    }

    /// <summary>
    /// Calculates and applies drag due to planetary gravity from a pre-calculated GravimetricResult
    /// </summary>
    /// <param name="grav">Pre-calculated GravimetricResult (contains a relative force of gravity and distance between planet and object at time of calculation)</param>
    public void ApplyDragDueToGravity(GravimetricResult grav)
    {
        //drag formula: atmospheric unit - (distance in megametres / scaling factor) = drag
        //example distant planet drag calc: 0.25 - (24457 / 100000) = 0.00543 = extremely low drag
        //example close planet drag calc: 0.25 - (1500 / 100000) = 0.235 = extremely high drag

        float drag = AtmosphericUnit - (grav.GetDistanceBetweenObjectAndBody() / ScaleFactor); //calculate drag from gravimetrics result's distance
        if (GetComponent<Rigidbody>().drag + drag > 0) GetComponent<Rigidbody>().drag += drag; //ensure applying drag never results in a minus drag value
    }

    /// <summary>
    /// For resetting drag when Gravimetrics' FixedUpdate() is recalculating total drag
    /// </summary>
    public void ResetDrag() { GetComponent<Rigidbody>().drag = 0; }
}