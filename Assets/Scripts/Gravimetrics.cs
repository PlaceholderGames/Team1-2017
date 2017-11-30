/// <summary>
/// NU GRAVITY script
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
    public bool boolAllowFixedStationary = true; //tells FixedUpdate to run the stationary method for debugging
    public GameObject objToOrbit; //object to orbit (singular object for demo)
    private GameObject objThis;

    void FixedUpdate()
    {
        if (boolAllowFixedStationary)
            ApplyStationaryGravity();
    }

    public Vector3 GetMovementGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when on the move
        //pre-condition: method is called when the object is moving and is within range of a planet

        //1) declare Attraction vector3
        //2) get closest body
        //3) calculate relative distance
        //4) calculate force needed to adjust its position
        //5) translate force into Attraction vector3
        //6) return Attraction vector3

        Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position;
        float fltDistance = vctDirection.magnitude;
        Vector3 Attraction = vctDirection.normalized * fltDistance;
        return Attraction;
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