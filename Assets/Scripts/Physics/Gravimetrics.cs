/*
    purpose: provides gravity interactions to certain objects
    usage: for anything that is expected to simulate gravimetric behaviour
*/

using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
    public bool boolAllowFixedStationary = true; //flags to apply stationary gravity method (as override FOR DEBUGGING)
    public GameObject objToOrbit; //object to orbit (singular object for demo)
    public float fltIntensity = 1.0f; //scales gravity down

    //internal variables
	private const float fltG = 500f; //gravitational constant

    void FixedUpdate()
    {
        if (boolAllowFixedStationary) ApplyStationaryGravity();
    }

    public Vector3 GetMovementGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when on the move
        //usage: called when an object is actively being moved by either player or another movement script

        Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<ProbeVariables>().GetPosition();
        float fltDistance = vctDirection.magnitude;
        float fltMagnitude = fltG * ((objToOrbit.GetComponent<Rigidbody>().mass * GetComponent<Rigidbody>().mass) / Mathf.Pow(fltDistance, 2)); //calculates the magnitude of the gravitational force
        Vector3 vctForce = vctDirection.normalized * fltMagnitude;
        return vctForce;
    }

    public void ApplyStationaryGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when stationary
        //usage: called when an object is stationary (in terms of not being controlled by player or other script)

        Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position;
        float fltDistance = vctDirection.magnitude;
        GetComponent<Rigidbody>().AddForce(vctDirection.normalized * fltDistance);
    }
}