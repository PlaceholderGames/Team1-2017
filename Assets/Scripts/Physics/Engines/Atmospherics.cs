/*
    purpose: atmosphere physics (atmospherics) engine
    usage: for objects that require a simulation of the atmospheric entry effects
*/

using Assets.Scripts.Others;
using UnityEngine;

public class Atmospherics : MonoBehaviour
{
    private float AtmosphericUnit = 0.25f; //used as a base unit for calculating relative drag with
    private float ScaleFactor = 100000; //used for converting distance values into a scaled-down decimals

    //examplar variables for singular burning demo
    public int burnBound = 0; //bounds for when the probe should burn inside
    public GameObject objToBurnIn; //object that the probe burns up in (singular object for demo)
    public GameObject particles; //reference to particles effect for burning

    void FixedUpdate()
    {
        //try to apply atmopsheric burning
        BurnInAtmosphere(objToBurnIn.GetComponent<Rigidbody>(), burnBound);
    }

    public void BurnInAtmosphere(Rigidbody obj, float bound)
    {
        //purpose: checks if object is in range of a planet to simulate a burning effect of entering a planetary atmosphere
        //parametres:
            //(obj) current body to check if within bounds with
            //(bound) bound for check if effect should be used in
        //usage: inside internal FixedUpdate()
        
        //calculate relative distance between current object and body
        Vector3 direction = obj.position - GetComponent<ProbeVariables>().GetPosition();
        float distance = direction.magnitude;

        //decide whether burn particles should be enabled/decided
        if (distance > bound) particles.GetComponent<ParticleSystem>().Stop();
        else particles.GetComponent<ParticleSystem>().Play();
    }

    public void ApplyDragDueToGravity(GravimetricResult grav)
    {
        //purpose: calculates and applies drag due to planetary gravity from a pre-calculated GravimetricResult
        //parametres:
            //(grav) pre-calculated GravimetricResult (contains a relative force of gravity and distance between planet and current object at time of calculation)
        //usage: called by the physics FixedUpdate() inside Gravimetrics class when method is calculating gravity

        //drag formula: atmospheric unit - (distance in megametres / scaling factor) = drag
        //example distant planet drag calc: 0.25 - (24457 / 100000) = 0.00543 = extremely low drag
        //example close planet drag calc: 0.25 - (1500 / 100000) = 0.235 = extremely high drag
        float drag = AtmosphericUnit - (grav.GetDistanceBetweenObjectAndBody() / ScaleFactor); //calculate drag from gravimetrics result's distance
        if (GetComponent<Rigidbody>().drag + drag > 0) GetComponent<Rigidbody>().drag += drag; //ensure applying drag never results in a minus drag value
    }

    public void ResetDrag() { GetComponent<Rigidbody>().drag = 0; } //usage: when Gravimetrics' FixedUpdate() is recalculating total drag
}