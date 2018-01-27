/*
    purpose: makes an object rotate on the spot
    usage: designed only for stellar bodies to give them a natural rotation
*/

using UnityEngine;

public enum Rotation { clockwise,anticlockwise }; //enumeration to allow change in direction in designer

public class ObjectRotator : MonoBehaviour 
{
	public float fltSpeed = 0.75f; //speed of rotation
	public Rotation rotation; //direction of rotation

	void Update()
    {
		//usage: constantly rotates the object at each frame render
		
		if (rotation == Rotation.clockwise) transform.Rotate(Vector3.up, fltSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.down, fltSpeed * Time.deltaTime);
	}
}