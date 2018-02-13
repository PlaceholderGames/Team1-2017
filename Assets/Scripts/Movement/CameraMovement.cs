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
    private GameObject probe; //reference to probe object


    void Start()
    {
        //purpose: captures reference to player by Tag
        probe = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (probe)
        {
            Vector3 vctPlayerPos = new Vector3(probe.GetComponent<ProbeObject>().GetPosition().x + XAdjust, probe.GetComponent<ProbeObject>().GetPosition().y + YAdjust, probe.GetComponent<ProbeObject>().GetPosition().z + ZAdjust);
            transform.position = vctPlayerPos;
        }
    }
}