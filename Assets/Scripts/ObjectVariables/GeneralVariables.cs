/*
    purpose: general variables object for all entities - serves as the base class for all Variable objects
    usage: only used when a child class is not available for an entity
*/

using System;
using UnityEngine;

public class GeneralVariables : MonoBehaviour
{
    //object variables
    public string Population = "0"; //amount of humans living on this body
    public float Health = 100.0f; //entity's health
    public bool ObjectFixed = false; //flags whether the entity should be fixed or movable

    virtual public void DerivedStart() { } //allows child classes to add start tasks via polymorphism
    virtual public void DerivedFixedUpdate() { } //allows child classes to add physics tasks via polymorphism

    void Start()
    {
        //purpose: runs object start tasks
        DerivedStart();
    }

    void FixedUpdate()
    {
        //purpose: runs object physics tasks
        DerivedFixedUpdate();
    }

    //variable getters
    public Vector3 GetPosition() { return GetComponent<Rigidbody>().position; }
    public Quaternion GetRotation() { return GetComponent<Rigidbody>().rotation; }
    public float GetMass() { return GetComponent<Rigidbody>().mass; }
    public void SetPopulation(long newPopulation) { Population = newPopulation.ToString(); }
    public long GetPopulation() { return Convert.ToInt64(Population); }
}