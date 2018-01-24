/*
    purpose: ensures camera moves with player
    usage: attached to main camera
*/

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float YAdjust = 0.0f; //override for adjusting Y-axis of player relative to camera
    private GameObject probe; //reference to probe object

	void Start()
    {
        //purpose: captures reference to player by Tag
        probe = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate()
    {
        //purpose: transforms camera position relative to player

        Vector3 vctPlayerPos = new Vector3(probe.GetComponent<ProbeVariables>().GetPosition().x, probe.GetComponent<ProbeVariables>().GetPosition().y + YAdjust, probe.GetComponent<ProbeVariables>().GetPosition().z);
        transform.position = vctPlayerPos;
    }
}