using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed;
    Transform playerTransform;

	void Start ()
    {
        //get/access player transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate ()
    {
        //lerp the camera roatiton for a smooth effect
        transform.rotation = Quaternion.Lerp(transform.rotation, playerTransform.rotation, rotateSpeed * Time.deltaTime);
	}
}
