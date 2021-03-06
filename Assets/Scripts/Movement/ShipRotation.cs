﻿using UnityEngine;

/// <summary>
/// Handles probe rotational (angular) movement
/// </summary>
public class ShipRotation : MonoBehaviour
{
    /// <summary>
    /// I think its the speed at which the probe turns based on mouse cursor??? (why didn't you comment these Andrea?)
    /// </summary>
    public float lookSpeed;

    /// <summary>
    /// Speed at which the probe rotates
    /// </summary>
    public float rotateSpeed;

    /// <summary>
    /// 
    /// </summary>
    public float centerRadius;

    /// <summary>
    /// Seems to be some sort of override adjustment
    /// </summary>
    public float controlVar;

    /// <summary>
    /// Local reference to probe object
    /// </summary>
    private GameObject probe; 

    /// <summary>
    /// Center of the screen's resolution
    /// </summary>
    Vector2 screenCenter;

    void Start()
    {
        //calculate screen center coordinates
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        //get/access ship's rigidbody component
        probe = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
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
            probe.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, 1.5f * rotateSpeed * Time.deltaTime);
        }
        //else if key D is help
        else if (Input.GetKey(KeyCode.D))
        {
            //apply torque on axis Z based on rotation speed value -> rotate towards right
            probe.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, 1.5f * -rotateSpeed * Time.deltaTime);
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
                probe.GetComponent<Rigidbody>().AddRelativeTorque(0, lookSpeed * (Time.deltaTime * mousePosRight / controlVar), 0);
                probe.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, -rotateSpeed * (Time.deltaTime * mousePosRight / controlVar));
            }
            //else if mouse position left from center
            else if (Input.mousePosition.x < screenCenter.x)
            {
                //calculate torque on axis Y and Z
                probe.GetComponent<Rigidbody>().AddRelativeTorque(0, -lookSpeed * (Time.deltaTime * mousePosLeft / controlVar), 0);
                probe.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, rotateSpeed * (Time.deltaTime * mousePosLeft / controlVar));
            }
            //if mouse position down from center
            if (Input.mousePosition.y > screenCenter.y)
            {
                probe.GetComponent<Rigidbody>().AddRelativeTorque(-lookSpeed * (Time.deltaTime * mousePosBot / controlVar), 0, 0);
            }
            //if mouse position up from center
            else if (Input.mousePosition.y < screenCenter.y)
            {
                probe.GetComponent<Rigidbody>().AddRelativeTorque(lookSpeed * (Time.deltaTime * mousePosTop / controlVar), 0, 0);
            }
        }
    }
}