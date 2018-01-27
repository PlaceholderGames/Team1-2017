/*
    purpose: gravity physics (gravimetrics) engine
    usage: for objects that require a simulation of the effects of gravity
*/

using Assets.Scripts.Others;
using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
	private const float G = 0.6674f; //gravitational constant
    public BodyVariables[] Bodies; //container of all planetary bodies

    void FixedUpdate()
    {
        //apply gravimetric effect to object from all bodies
        GravimetricResult currentGrav = new GravimetricResult(new Vector3(0,0,0), 0);
        GetComponent<Atmospherics>().ResetDrag(); //reset drag so new calculation can be used
        for (int i = 0; i < Bodies.Length; i++)
        {
            currentGrav = GetMovementGravity(Bodies[i]); //get gravity calculation result
            GetComponent<Rigidbody>().AddRelativeForce(currentGrav.GetForce()); //apply gravimetric force
            GetComponent<Atmospherics>().ApplyDragDueToGravity(currentGrav); //call for atmospheric drag to be applied
        }
    }

    public GravimetricResult GetMovementGravity(BodyVariables body)
    {
        //purpose: calculates a gravimetric result optimised for when the probe is moving
        //parametres:
            //(body) body to calculate gravity with
        //usage: for when the probe is moving and needs a GravityProperties result for application elsewhere

        Vector3 direction = body.GetPosition() - GetComponent<ProbeVariables>().GetPosition(); //work out direction between both objects
        float distance = direction.magnitude; //get distance from direction
        float magnitude = G * ((body.GetMass() * GetComponent<ProbeVariables>().GetMass()) / Mathf.Pow(distance, 2)); //calculates the magnitude of the gravitational force
        Vector3 force = direction.normalized * (magnitude * body.GravimetricStrength); //convert calculation into workable force
        return new GravimetricResult(force, distance);
    }
}