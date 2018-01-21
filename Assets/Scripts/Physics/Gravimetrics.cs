/// <summary>
/// NU GRAVITY script
/// </summary>
using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
    public bool boolAllowFixedStationary = true; //tells FixedUpdate to run the stationary method for debugging
    public GameObject objToOrbit; //object to orbit (singular object for demo)
    public float fltIntensity = 1.0f; //scales gravity down

    //internal variables
	private const float fltG = 500f; //gravitational constant

    void FixedUpdate()
    {
        if (boolAllowFixedStationary)
            ApplyStationaryGravity();
    }

    public Vector3 GetMovementGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when on the move
        //pre-condition: method is called when the object is moving and is within range of a planet

        Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<ProbeVariables>().GetPosition();
        float fltDistance = vctDirection.magnitude;
        float fltMagnitude = fltG * ((objToOrbit.GetComponent<Rigidbody>().mass * GetComponent<Rigidbody>().mass) / Mathf.Pow(fltDistance, 2)); //calculates the magnitude of the gravitational force
        Vector3 vctForce = vctDirection.normalized * fltMagnitude;
        return vctForce;
    }

    public void ApplyStationaryGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when stationary
        
        //1) get closest body
        //2) calculate relative direction
        //3) calculate distance
        //4) calculate force 
        //5) push object towards body directly

        Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position;
        float fltDistance = vctDirection.magnitude;
        GetComponent<Rigidbody>().AddForce(vctDirection.normalized * fltDistance);
    }
}