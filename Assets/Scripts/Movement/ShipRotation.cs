using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour {

    public float lookSpeed;
    public float rotateSpeed;
    public float centerRadius;
    public float controlVar;

    Rigidbody ship;
    public Gravimetrics gv;
    public Vector2 screenCenter;

	void Start () {
        //calculate screen center coordinates
        screenCenter = new Vector2(Screen.width/2, Screen.height/2);
        //get/access ship's rigidbody component
        ship = GetComponent<Rigidbody>();
	}
	
	void Update () {
        //calculate distance between current mousse position and center of screen
        float mouseDistFromCenter = Vector2.Distance(Input.mousePosition, screenCenter);

        //calculate mouse position values per quadrants
        float mousePosRight = Input.mousePosition.x - screenCenter.x;
        float mousePosLeft = screenCenter.x - Input.mousePosition.x;
        float mousePosBot = Input.mousePosition.y - screenCenter.y;
        float mousePosTop = screenCenter.y - Input.mousePosition.y;

        ///////////////////////////////////
        //Precise torque control via keys//
        ///////////////////////////////////

        //if key A is held
        if (Input.GetKey(KeyCode.A))
        {
            //apply torque on axis Z based on rotation speed value -> rotate towards left
            Vector3 vctForce = gv.GetMovementGravity();
            vctForce.z = 1.5f * rotateSpeed * Time.deltaTime;
            ship.AddTorque(vctForce);
        }
        //else if key D is help
        else if (Input.GetKey(KeyCode.D))
        {
            //apply torque on axis Z based on rotation speed value -> rotate towards right
            Vector3 vctForce = gv.GetMovementGravity();
            vctForce.z = -1.5f * rotateSpeed * Time.deltaTime;
            ship.AddTorque(vctForce);
        }

        //////////////////////////////////////
        // Look control via cursor position //
        //////////////////////////////////////

        if (mouseDistFromCenter > centerRadius)   //ship's focus/position doesn't change in a small radius in the center of the screen
        {
            //if mouse position right from center
            if (Input.mousePosition.x > screenCenter.x)
            {
                //calculate torque on axis Y and Z
                ship.AddRelativeTorque(0, lookSpeed * (Time.deltaTime * mousePosRight / controlVar), 0);
                ship.AddRelativeTorque(0, 0, -rotateSpeed * (Time.deltaTime * mousePosRight / controlVar));
            }
            //else if mouse position left from center
            else if (Input.mousePosition.x < screenCenter.x)
            {
                //calculate torque on axis Y and Z
                ship.AddRelativeTorque(0, -lookSpeed * (Time.deltaTime * mousePosLeft / controlVar), 0);
                ship.AddRelativeTorque(0, 0, rotateSpeed * (Time.deltaTime * mousePosLeft / controlVar));
            }
            //if mouse position down from center
            if (Input.mousePosition.y > screenCenter.y)
            {
                ship.AddRelativeTorque(-lookSpeed * (Time.deltaTime * mousePosBot / controlVar), 0, 0);
            }
            //if mouse position up from center
            else if (Input.mousePosition.y < screenCenter.y)
            {
                ship.AddRelativeTorque(lookSpeed * (Time.deltaTime * mousePosTop / controlVar), 0, 0);
            }
        }
    }
}
