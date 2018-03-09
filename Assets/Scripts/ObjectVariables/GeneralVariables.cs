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

    //other stats
    private Vector3 SpeedCurrent;
    private float SpeedLimit = 100000;

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
        SpeedCurrent = GetComponent<Rigidbody>().velocity;
        //SpeedLimiter();
        DerivedFixedUpdate();
    }

    private void SpeedLimiter()
    {
        //purpose: ensure object does not exceed top speed
        //usage: internal DerivedFixedUpdate()

        if ((SpeedCurrent.magnitude * 3.6f) >= SpeedLimit)
        {
            //if probe is exceeding top speed, cap the values of the offending vectors inside the velocity vector
            Vector3 cappedVelocity = new Vector3();

            if ((SpeedCurrent.x * 3.6f) >= SpeedLimit) cappedVelocity.x = (SpeedLimit / 3.6f);
            else cappedVelocity.x = SpeedCurrent.x;

            if ((SpeedCurrent.y * 3.6f) >= SpeedLimit) cappedVelocity.y = (SpeedLimit / 3.6f);
            else cappedVelocity.y = SpeedCurrent.z;

            if ((SpeedCurrent.z * 3.6f) >= SpeedLimit) cappedVelocity.z = (SpeedLimit / 3.6f);
            else cappedVelocity.z = SpeedCurrent.z;

            SpeedCurrent = GetComponent<Rigidbody>().velocity = cappedVelocity;
        }
        else SpeedCurrent = GetComponent<Rigidbody>().velocity; //if probe is below speed limit, just get velocity for local copy
    }

    //variable getters
    public Vector3 GetPosition() { return GetComponent<Rigidbody>().position; }
    public Quaternion GetRotation() { return GetComponent<Rigidbody>().rotation; }
    public float GetMass() { return GetComponent<Rigidbody>().mass; }
    public void SetPopulation(long newPopulation) { Population = newPopulation.ToString(); }
    public long GetPopulation() { return Convert.ToInt64(Population); }
    public float GetCurrentSpeed() { return SpeedCurrent.magnitude * 3.6f; /* multiplying result by 3.6 converts m/s to KPH */ }
    public float GetSpeedLimit() { return SpeedLimit; }
    virtual public float GetSize() { return 0; }
}