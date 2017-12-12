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
    public float fltIntensity = 0.1f; //scales gravity down

    //internal variables
	private const float fltG = 6674f; //gravitational constant

    void FixedUpdate()
    {
        if (boolAllowFixedStationary)
            ApplyStationaryGravity();
    }

    public Vector2 GetMovementGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when on the move
        //pre-condition: method is called when the object is moving and is within range of a planet


        Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position;
        float fltDistance = vctDirection.magnitude;
        float fltMagnitude = fltG * ((objToOrbit.GetComponent<Rigidbody>().mass * GetComponent<Rigidbody>().mass) / Mathf.Pow(fltDistance, 2)); //calculates the magnitude of the gravitational force
        Vector2 vctForce = vctDirection.normalized * fltMagnitude;
        return vctForce;

        //Vector3 vctDirection = objToOrbit.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position;
        //float fltDistance = vctDirection.magnitude;
        //Vector3 Attraction = vctDirection.normalized * (fltDistance * fltIntensity);
        //return Attraction;
        //return new Vector3(0.0f, 0.0f, 0.0f);
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

 //   void Attract(Gravimetrics objToAttract)
	//{
	//	//usage: applies gravity via Newton's law of universal gravitation
	//	//parametres: (objToAttract) object that needs to have gravity applied

	//	Rigidbody rbToAttract = objToAttract.rb; //allows access of information from the other object's rigidbody
	//	Vector3 vctDirection = rb.position - rbToAttract.position; 
	//	float fltDistance = vctDirection.magnitude; 
	//	if (fltDistance == 0f) //prevents errors with on-the-fly duplication of objects
	//		return;
	//	float fltMagnitude = fltG * ((rb.mass * rbToAttract.mass) / Mathf.Pow(fltDistance, 2)); //calculates the magnitude of the gravitational force
	//	Vector3 vctForce = vctDirection.normalized * fltMagnitude;
	//	rbToAttract.AddForce(vctForce);
	//}

 //   void Orbit()
 //   {
	//	//usage: applies specified accelerate to create an orbit
	//	transform.position += Vector3.forward* Time.deltaTime * fltAcceleration;
 //   }
}