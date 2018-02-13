/*
    purpose: general object variables and events class - serves as base class for all other object classes
    usage: only used when a child class is not available for an entity
*/

using System;
using UnityEditor;
using UnityEngine;

public class GeneralObject : MonoBehaviour
{
    //object variables
    public string Population = "0"; //amount of humans living on this body
    public float Health = 100.0f; //entity's health
    public bool ObjectFixed = false; //flags whether the entity should be fixed or movable
    private GameObject[] Explosions = new GameObject[4];

    //other stats
    private Vector3 SpeedCurrent;
    private float SpeedLimit = 100000;

    //virtual methods to allow inheritng clases to add their own tasks to core Unity functions via polymorphism
    virtual public void DerivedStart() { } 
    virtual public void DerivedFixedUpdate() { } 

    void Start()
    {
        //load explosion types
        Explosions[0] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/Explosion01a.prefab", typeof(GameObject)) as GameObject;
        Explosions[1] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/Explosion01b.prefab", typeof(GameObject)) as GameObject;
        Explosions[2] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/Explosion01v.prefab", typeof(GameObject)) as GameObject;
        Explosions[3] = AssetDatabase.LoadAssetAtPath("Assets/Effects/Particles/SimpleParticlePack/Resources/Explosions/Explosion02.prefab", typeof(GameObject)) as GameObject;

        DerivedStart();
    }

    void FixedUpdate()
    {
        if (Health <= 0) //check health
        {
            //handle destruction of current object
            Explode(true);
        }
        DerivedFixedUpdate(); //call derived fixed update tasks
    }

    //events
    public void Explode(bool destroy)
    {
        if (destroy) Destroy(gameObject);
        for (int i = 0; i < 5; i++) //create five different explosions
        {
            GameObject newExplosion = Instantiate(Explosions[UnityEngine.Random.Range(0, Explosions.Length - 1)], GetPosition(), new Quaternion(0, 0, 0, 0));
            newExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(newExplosion, 3);
        }
    }

    //variable getters
    public Vector3 GetPosition() { return GetComponent<Rigidbody>().position; }
    public Quaternion GetRotation() { return GetComponent<Rigidbody>().rotation; }
    public float GetMass() { return GetComponent<Rigidbody>().mass; }
    public void SetPopulation(long newPopulation) { Population = newPopulation.ToString(); }
    public long GetPopulation() { return Convert.ToInt64(Population); }
    public float GetCurrentSpeed() { return GetComponent<Rigidbody>().velocity.magnitude * 3.6f; /* multiplying result by 3.6 converts m/s to KPH */ }
    public float GetSpeedLimit() { return SpeedLimit; }
    virtual public float GetSize() { return 0; }
}