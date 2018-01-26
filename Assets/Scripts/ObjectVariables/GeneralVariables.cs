/*
    purpose: general variables object for all entities - serves as the base class for all Variable objects
    usage: only used when a child class is not available for an entity
*/

using UnityEngine;

public class GeneralVariables : MonoBehaviour
{
    //object variables
    public int Population = 0; //among of humans living on this body
    public float Health = 100.0f; //entity's health
    public bool ObjectFixed = false; //flags whether the entity should be fixed or movable

    virtual public void DerivedStartTasks() { } //allows child classes to add start tasks via polymorphism
    virtual public void DerivedFixedUpdateTasks() { } //allows child classes to add physics tasks via polymorphism

    void Start()
    {
        //purpose: runs object start tasks
        DerivedStartTasks();
    }

    void FixedUpdate()
    {
        //purpose: runs object physics tasks
        DerivedFixedUpdateTasks();
    }

    //variable getters
    public Vector3 GetPosition() { return GetComponent<Rigidbody>().position; }
    public Quaternion GetRotation() { return GetComponent<Rigidbody>().rotation; }
    public float GetMass() { return GetComponent<Rigidbody>().mass; }
}