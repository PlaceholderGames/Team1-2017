using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rotation { clockwise,anticlockwise };

public class ObjectRotator : MonoBehaviour 
{
	public float fltSpeed = 0f; //speed of rotation
	public Rotation rotation; //direction of rotation

	void Update()
    {
		//usage: constantly rotates the object at each frame render
		
		if (rotation == Rotation.clockwise)
			transform.Rotate(Vector3.up, fltSpeed * Time.deltaTime);
        else
			transform.Rotate(-Vector3.up, fltSpeed * Time.deltaTime);
	}
}