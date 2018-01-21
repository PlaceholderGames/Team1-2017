using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Transform playerTransform;

	void Start () {
        //get/access player transform 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate () {
        //lock camera to player position
        transform.position = playerTransform.position;
    }
}
