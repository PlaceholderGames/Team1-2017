/*
    purpose: provides gravity interactions to certain objects
    usage: for anything that is expected to simulate gravimetric behaviour
*/

using Assets.Scripts.Others;
using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
	private const float G = 0.6674f; //gravitational constant
    public BodyVariables[] Bodies; //container of all plantery bodies

    void FixedUpdate()
    {
        //purpose: applies gravity

        GravityProperties currentGrav = new GravityProperties(new Vector3(0,0,0), 0, 0);
        GetComponent<Rigidbody>().drag = 0; //reset drag so new calculation can be used

        for (int i = 0; i < Bodies.Length; i++)
        {
            currentGrav = GetMovementGravity(i);
            GetComponent<Rigidbody>().AddRelativeForce(currentGrav.GetForce());
            if (GetComponent<Rigidbody>().drag + currentGrav.GetDragDueToAtmosphere() > 0) GetComponent<Rigidbody>().drag += currentGrav.GetDragDueToAtmosphere();
        }
    }

    public GravityProperties GetMovementGravity(int index)
    {
        //purpose: returns a vector 
        //parametres:
        //(index) body to calculate gravity with
        //usage: called when an object is actively being moved by either player or another movement script

        Vector3 direction = Bodies[index].GetPosition() - GetComponent<ProbeVariables>().GetPosition(); //work out direction between both objects
        float distance = direction.magnitude; //get distance from direction
        float dragDueToAtmopshere = 0.25f - (distance / 100000); //calculate drag due to atmosphere based on how close probe is to planetary body
        Debug.Log(dragDueToAtmopshere);
        float magnitude = G * ((Bodies[index].GetMass() * GetComponent<ProbeVariables>().GetMass()) / Mathf.Pow(distance, 2)); //calculates the magnitude of the gravitational force
        Vector3 force = direction.normalized * (magnitude * Bodies[index].GravimetricStrength); //convert calculation into workable force
        return new GravityProperties(force, distance, dragDueToAtmopshere);
    }
}