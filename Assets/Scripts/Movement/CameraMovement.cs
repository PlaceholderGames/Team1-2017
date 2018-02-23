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
    private GeneralObject follow; //reference to follow object


    void Start()
    {
        //purpose: captures reference to player by Tag
        follow = GameObject.FindGameObjectWithTag("Player").GetComponent<GeneralObject>();
    }

    void Update()
    {
        if (follow)
        {
            //transform position
            Vector3 vctPlayerPos = new Vector3(follow.GetPosition().x + XAdjust, follow.GetPosition().y + YAdjust, follow.GetPosition().z + ZAdjust);
            transform.position = vctPlayerPos;

            //lerp the camera roatiton for a smooth effect
            transform.rotation = Quaternion.Lerp(transform.rotation, follow.GetRotation(), rotateSpeed * Time.deltaTime);
        }
    }
}