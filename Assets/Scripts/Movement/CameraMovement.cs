using UnityEngine;

/// <summary>
/// Ensures camera moves with player
/// </summary>
public class CameraMovement : MonoBehaviour
{
    /// <summary>
    /// Override for adjusting X-axis of player relative to camera
    /// </summary>
    public float XAdjust = 0.0f;

    /// <summary>
    /// Override for adjusting Y-axis of player relative to camera
    /// </summary>
    public float YAdjust = 0.0f;

    /// <summary>
    /// Override for adjusting Z-axis of player relative to camera
    /// </summary>
    public float ZAdjust = 0.0f;

    /// <summary>
    /// Speed in which the camera rotates with the player att
    /// </summary>
    public float rotateSpeed;

    /// <summary>
    /// Reference of object the camera is following
    /// </summary>
    private GeneralObject follow;


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