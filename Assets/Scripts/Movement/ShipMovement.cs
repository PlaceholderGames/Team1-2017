/*
    purpose: handles probe movement and gravity application
    usage: attached to probe
*/

using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 10000; //normal move speed
    public float reverseSpeed = -10000; //normal move speed
    public float superSpeed = 10000; //warped speed
    public float teleportSpeed = 0; //teleport distance
    private GameObject probe; //reference to probe object
    public GameObject speedometer; //reference to speedometer object

    void Start()
    {
        //purpose: captures reference to player by Tag
        probe = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //purpose: conducts probe movement if certain key(s) are pressed

        if (Input.GetKey(KeyCode.W)) //if key W is held
        {
            //apply force in positive direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, moveSpeed * Time.deltaTime, ForceMode.Force);
        }
        
        if (Input.GetKey(KeyCode.S)) //if key S is held
        {
            //apply force in negative direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, reverseSpeed * Time.deltaTime, ForceMode.Force);
        }
        
        if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W))//if both keys W and LShift are held
        {
            //apply additional force in direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, superSpeed * Time.deltaTime, ForceMode.Force);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) //if and when key Space is pressed
        {
            //apply a big amount of force in direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, teleportSpeed, ForceMode.Force);
        }

        //manage speed tasks
        if (speedometer != null)
        {
            speedometer.GetComponent<Text>().text = probe.GetComponent<ProbeVariables>().GetSpeed().ToString();
        }
    }
}