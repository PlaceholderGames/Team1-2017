/// <summary>
/// GRAVIMETRICS gravity physics script
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Body { planet, satellite }; //enumeration of body types

public class Gravimetrics : MonoBehaviour
{
	//inspector variables
	public Body body; //type of body this object is
	public Rigidbody rb; //object's rigidbody
	public float fltAcceleration; //object's acceleration (only used if object is a satellite)
	
	//internal variables
	private const float fltG = 6674f; //gravitational constant
	public static List<Gravimetrics> lstGravimetrics; //local container of references to all gravity-enabled objects
	
    void Update()
    {
        //usage: frame updates; continuously applies orbit motion to all satellite bodies

        foreach (Gravimetrics obj in lstGravimetrics)
        {
			if (obj != this && obj.body != Body.satellite) //if object in list isn't this object OR if object in list isn't also a satellite
				Orbit();
        }
    }
	
    void FixedUpdate()
	{
		//usage: physics updates; continuously applies the gravitational effect to all objects that are capable of being attracted

		foreach (Gravimetrics obj in lstGravimetrics)
		{
			if (obj != this) //if object in list isn't this object
                Attract(obj);
		}
	}

	void OnEnable()
	{
		//usage: adds gravity-enabled object on creation to a list of objects

		if (lstGravimetrics == null)
            lstGravimetrics = new List<Gravimetrics>();
        lstGravimetrics.Add(this);
	}

	void onDisable()
	{
        //usage: removes gravity-enabled object from the list of objects
        lstGravimetrics.Remove(this);
	}

	void Attract(Gravimetrics objToAttract)
	{
		//usage: applies gravity via Newton's law of universal gravitation
		//parametres: (objToAttract) object that needs to have gravity applied

		Rigidbody rbToAttract = objToAttract.rb; //allows access of information from the other object's rigidbody
		Vector3 vctDirection = rb.position - rbToAttract.position; 
		float fltDistance = vctDirection.magnitude; 
		if (fltDistance == 0f) //prevents errors with on-the-fly duplication of objects
			return;
		float fltMagnitude = fltG * ((rb.mass * rbToAttract.mass) / Mathf.Pow(fltDistance, 2)); //calculates the magnitude of the gravitational force
		Vector3 vctForce = vctDirection.normalized * fltMagnitude;
		rbToAttract.AddForce(vctForce);
	}

    void Orbit()
    {
		//usage: applies specified accelerate to create an orbit
		transform.position += Vector3.forward * Time.deltaTime * fltAcceleration;
    }
}