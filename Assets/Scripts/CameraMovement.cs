/*
    purpose: ensures camera moves with player
    usage: attached to main camera
*/

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float XAdjust = 0.0f; //override for adjusting X-axis of player relative to camera
    public float YAdjust = 0.0f; //override for adjusting Y-axis of player relative to camera
    public float ZAdjust = 0.0f; //override for adjusting Z-axis of player relative to camera
    public float rotateSpeed;
    public GameObject Ship;
   // private GeneralObject follow; //reference to follow object


    void Start()
    {
        //purpose: captures reference to player by Tag
        Ship = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Ship)
        {
            Vector3 vctPlayerPos = new Vector3(Ship.transform.position.x + XAdjust, Ship.transform.position.y + YAdjust, Ship.transform.position.z + ZAdjust);
            transform.position = vctPlayerPos;


            //lerp the camera roatiton for a smooth effect
            transform.rotation = Quaternion.Lerp(transform.rotation, Ship.transform.rotation, 8 * Time.deltaTime);
        }
    }
}
