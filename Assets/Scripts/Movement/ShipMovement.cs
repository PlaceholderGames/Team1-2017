/*
    purpose: handles probe movement and gravity application
    usage: attached to probe
*/

using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed; //normal move speed
    public float superSpeed; //warped speed
    public float teleportSpeed; //teleport distance
    private GameObject probe; //reference to probe object

    void Start()
    {
        //purpose: captures reference to player by Tag
        probe = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //if key W is held
        if (Input.GetKey(KeyCode.W))
        {
            //apply force in positive direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, moveSpeed * Time.deltaTime, ForceMode.Force);
        }
        //if key S is held
        if (Input.GetKey(KeyCode.S))
        {
            //apply force in negative direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, -moveSpeed * Time.deltaTime, ForceMode.Force);
        }

        //if both keys W and LShift are held
        if (Input.GetKey(KeyCode.LeftShift) & Input.GetKey(KeyCode.W))
        {
            //apply additional force in direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, superSpeed * Time.deltaTime, ForceMode.Force);
        }

        //if and when key Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //apply a big amount of force in direction of local Z axis
            probe.GetComponent<Rigidbody>().AddRelativeForce(0, 0, teleportSpeed, ForceMode.Force);
        }
    }
}