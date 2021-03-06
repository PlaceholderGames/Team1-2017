﻿/*
    purpose: general object variables and events class - serves as base class for all other object classes
    usage: only used when a child class is not available for an entity
*/

using System;
using UnityEngine;

public class GeneralObject : MonoBehaviour
{
    //object variables
    public string Population = "0"; //amount of humans living on this body
    public float Health = 100.0f; //entity's health
    public bool ObjectFixed = false; //flags whether the entity should be fixed or movable
    protected GameObject[] Explosions = new GameObject[4];

    //virtual methods to allow inheritng classes to add their own tasks to core Unity functions via polymorphism
    virtual public void DerivedStart() { } 
    virtual public void DerivedFixedUpdate() { } 

    void Start()
    {
        //load explosion types
        Explosions = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ExplosionPrefabProvider>().Explosions;
        DerivedStart(); //calles DerivedStart to allow child classes to use this subroutine to place tasks into Start without overriding completely
    }

    void FixedUpdate()
    {
        if (Health <= 0) Explode(true); //if health gone, handle destruction of current object
        DerivedFixedUpdate();//calles DerivedFixedUpdate to allow child classes to use this subroutine to place tasks into FixeddUpdate without overriding completely
    }

    //events
    public void Explode(bool DestroyObject, int DestroyInSeconds = 3)
    {
        //purpose: creates explosion effect around the object 
        //parametres:
            //(DestroyObject) flags whether the method should also remove the object from the game
            //(DestroyInSeconds) indicates in how many seconds should Object.Destroy actually remove the object from the game

        GameObject SelectedExplosion = Explosions[UnityEngine.Random.Range(0, Explosions.Length - 1)];
        GameObject newExplosion = Instantiate(SelectedExplosion, GetPosition(), new Quaternion(0, 0, 0, 0));
        if (newExplosion != null)
        {
            newExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(newExplosion, DestroyInSeconds);
        }
        if (DestroyObject) Destroy(gameObject);
    }

    //variable getters
    public Vector3 GetPosition() { return GetComponent<Rigidbody>().position; }
    public Quaternion GetRotation() { return GetComponent<Rigidbody>().rotation; }
    public float GetMass() { return GetComponent<Rigidbody>().mass; }
    public void SetPopulation(long newPopulation) { Population = newPopulation.ToString(); }
    public long GetPopulation() { return Convert.ToInt64(Population); }
    public float GetCurrentSpeed() { return GetComponent<Rigidbody>().velocity.magnitude * 3.6f; /* multiplying result by 3.6 converts m/s to KPH */ }
    virtual public float GetSize() { return 0; /* only supposed to be used by BodyObject */ }
}