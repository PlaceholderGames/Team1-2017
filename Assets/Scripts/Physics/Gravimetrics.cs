/*
    purpose: provides gravity interactions to certain objects
    usage: for anything that is expected to simulate gravimetric behaviour
*/

using System.Collections.Generic;
using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
	private const float G = 0.06674f; //gravitational constant
    public BodyVariables[] Bodies; //container of all plantery bodies

    void FixedUpdate()
    {
        //purpose: applies gravity
        for (int i = 0; i < Bodies.Length; i++) GetComponent<Rigidbody>().AddRelativeForce(GetMovementGravity(i));
    }

    public Vector3 GetMovementGravity(int index)
    {
        //purpose: 
        //parametres:
            //(index) body to calculate gravity with
        //usage: called when an object is actively being moved by either player or another movement script

        Vector3 direction = Bodies[index].GetPosition() - GetComponent<ProbeVariables>().GetPosition();
        float distance = direction.magnitude;
        float magnitude = G * ((Bodies[index].GetMass() * GetComponent<ProbeVariables>().GetMass()) / Mathf.Pow(distance, 2)); //calculates the magnitude of the gravitational force
        Vector3 force = direction.normalized * (magnitude * Bodies[index].GravimetricStrength);
        return force;
    }

    //public void ApplyStationaryGravity()
    //{
    //    //purpose: calculates satellite's attraction towards a planetary body when stationary
    //    //usage: called when an object is stationary (in terms of not being controlled by player or other script)

    //    //Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position;
    //    //float fltDistance = vctDirection.magnitude;
    //    //GetComponent<Rigidbody>().AddForce(vctDirection.normalized * fltDistance);
    //}
}