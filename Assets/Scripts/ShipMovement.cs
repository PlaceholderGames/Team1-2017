using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    //normal movement speed
    public float moveSpeed;
    public float superSpeed;
    public float teleportSpeed;

    Rigidbody ship;
    public Gravimetrics gv;
    public Camera cm;

    void Start ()
    {
        //get/access ship's rigidbody component
        ship = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        //if key W is held
        if (Input.GetKey(KeyCode.W))
        {
            //apply force in positive direction of local Z axis
            Vector2 vctAttraction = gv.GetMovementGravity();
            ship.AddRelativeForce(vctAttraction.x, vctAttraction.y, moveSpeed * Time.deltaTime, ForceMode.Force);
        }
        //if key S is held
        if (Input.GetKey(KeyCode.S))
        {
            //apply force in negative direction of local Z axis
            Vector2 vctAttraction = gv.GetMovementGravity();
            ship.AddRelativeForce(vctAttraction.x, vctAttraction.y, -moveSpeed * Time.deltaTime, ForceMode.Force);
        }

        //if both keys W and LShift are held
            if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W))
        {
            //apply additional force in direction of local Z axis
            Vector2 vctAttraction = gv.GetMovementGravity();
            ship.AddRelativeForce(vctAttraction.x, vctAttraction.y, superSpeed * Time.deltaTime, ForceMode.Force);
        }

        //if and when key Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //apply a big amount of force in direction of local Z axis
            Vector2 vctAttraction = gv.GetMovementGravity();
            ship.AddRelativeForce(vctAttraction.x, vctAttraction.y, teleportSpeed, ForceMode.Force);
        }
    }
}
