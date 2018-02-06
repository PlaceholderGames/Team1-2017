/*
    purpose: atmosphere physics (atmospherics) engine
    usage: for objects that require a simulation of the atmospheric entry effects
*/

using Assets.Scripts.Others;
using UnityEngine;

public class Atmospherics : MonoBehaviour
{
    public float AtmosphericUnit = 0.25f; //used as a base unit for calculating relative drag with
    public float ScaleFactor = 100000; //used for converting distance values into a scaled-down decimals
    public float InteractivityRange = 100; //declares how close the object has to be for burning up
    public GameObject particles; //reference to particles effect for burning
    private BodyVariables[] Bodies; //container of all planetary bodies
    private bool[] isInRange; //array of flags that indicate what body the planet is within range of

    void Start()
    {
        //populate Bodies array with all planets
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //get local reference to all planets
        Bodies = new BodyVariables[planets.Length]; //initialise Bodies array
        for (int i = 0; i < planets.Length; i++) Bodies[i] = planets[i].GetComponent<BodyVariables>();

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

    private void attemptBurn()
    {
        //purpose: searches through isInRange array to see if burning effect should be applied
        //usage: inside internal FixedUpdate()

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

    public bool checkInRange(BodyVariables obj)
    {
        //purpose: checks if the object is in range of the passed through planetary body
        //parametres:
            //(obj) body's BodyVariables for getting planetary data from
        //usage: inside internal FixedUpdate()

        //calculate relative distance between object and body
        Vector3 direction = obj.GetPosition() - GetComponent<ProbeVariables>().GetPosition();
        float distance = direction.magnitude;

        //check if object and body are within range
        if (distance < obj.GetSize() + InteractivityRange) return true;
        else return false;
    }


    public void ApplyDragDueToGravity(GravimetricResult grav)
    {
        //purpose: calculates and applies drag due to planetary gravity from a pre-calculated GravimetricResult
        //parametres:
            //(grav) pre-calculated GravimetricResult (contains a relative force of gravity and distance between planet and object at time of calculation)
        //usage: called by the physics FixedUpdate() inside Gravimetrics class when method is calculating gravity

        //drag formula: atmospheric unit - (distance in megametres / scaling factor) = drag
        //example distant planet drag calc: 0.25 - (24457 / 100000) = 0.00543 = extremely low drag
        //example close planet drag calc: 0.25 - (1500 / 100000) = 0.235 = extremely high drag
        float drag = AtmosphericUnit - (grav.GetDistanceBetweenObjectAndBody() / ScaleFactor); //calculate drag from gravimetrics result's distance
        if (GetComponent<Rigidbody>().drag + drag > 0) GetComponent<Rigidbody>().drag += drag; //ensure applying drag never results in a minus drag value
    }

    public void ResetDrag() { GetComponent<Rigidbody>().drag = 0; } //usage: when Gravimetrics' FixedUpdate() is recalculating total drag
}