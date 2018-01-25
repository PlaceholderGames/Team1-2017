/*
    purpose: general variables object for all entities - serves as the base class for all Variable objects
    usage: only used when a child class is not available for an entity
*/

using UnityEngine;

public class GeneralVariables : MonoBehaviour
{
    //object variables
    private Vector3 Position; //entity's current position
    private Quaternion Rotation; //entity's current rotation
    public float Health = 100.0f; //entity's health
    public float GravimetricStrength = 1.0f; //gravimetric strength outputted by entity (used as a factoring variable)
    public bool ObjectFixed = false; //flags whether the entity should be fixed or movable

    virtual public void DerivedStartTasks() { } //allows child classes to add start tasks via polymorphism
    virtual public void DerivedFixedUpdateTasks() { } //allows child classes to add fixed update tasks via polymorphism

    void Start()
    {
        //purpose: grabs local copy of important Rigidbody values 
        //usage: should only be used if the entity is fixed on the map

        DerivedStartTasks();
        if (ObjectFixed)
        {
            Position = GetComponent<Rigidbody>().position;
            Rotation = GetComponent<Rigidbody>().rotation;
        }
    }

    void FixedUpdate()
    {
        //purpose: continously grabs local copy of important Rigidbody values
        //usage: should only be used if the entity is expected to move

        DerivedFixedUpdateTasks();
        if (!ObjectFixed) //only allow update if object is not fixed
        {
            Position = GetComponent<Rigidbody>().position;
            Rotation = GetComponent<Rigidbody>().rotation;
        }
    }

    //variable getters
    public Vector3 GetPosition() { return Position; }
    public Quaternion GetRotation() { return Rotation; }
}