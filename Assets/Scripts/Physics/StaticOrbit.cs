/*
    purpose: allows an object to orbit another object without gravimetric affects
    usage: designed for making planets around a sun or satellites around a planet
*/

using UnityEngine;

public class StaticOrbit : MonoBehaviour
{
    public GameObject objToOrbit; //object to orbit
    private Vector3 point; //target point to orbit around
    private Quaternion rotation; //calculated rotation

    void FixedUpdate()
    {
        Orbit();
    }

    public void Orbit()
    {
        //purpose: calculates path for object to move with

        point = objToOrbit.GetComponent<GeneralVariables>().GetPosition() - GetComponent<GeneralVariables>().GetPosition(); //work out positional distance
        rotation = Quaternion.LookRotation(-point, Vector3.up); //creates rotation with provided factors
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2.0f); //applies results as rotation transformation
    }
}