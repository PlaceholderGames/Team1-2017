/*
    purpose: tells an asteroid to go to a certain position
    usage: only for testing
*/

using UnityEngine;

public class StaticCourse : MonoBehaviour
{
    public Vector3 Destintation = new Vector3(0 ,0 ,0); //stores destination co-ords
    public float Stepper = 2; //travel distance per FixedUpdate()

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destintation, Stepper);
    }
}