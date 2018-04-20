using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Variables class for Asteroidal objects
/// </summary>
public class AsteroidObject : GeneralObject
{
    /// <summary>
    /// How fast the asteroid turns naturally
    /// </summary>
    [SerializeField]
    private float RotationSpeed = 0.01f;

    /// <summary>
    /// Enumeration of the natural turning direction of the object
    /// </summary>
    private ROTATION OrbitRotation;

    /// <summary>
    /// Flags whether the asteroid is on a collision course with a population centers
    /// </summary>
    [SerializeField]
    private bool Chasing = false;

    /// <summary>
    /// Target for when the asteroid is 'chasing'
    /// </summary>
    private GeneralObject Target;

    /// <summary>
    /// Derived code to be executed in the superclass (GeneralObject) Start() method
    /// </summary>
    override public void DerivedStart()
    {
        //randomise the scale of the asteroid
        gameObject.transform.localScale *= 1f + Random.Range(0.0f, 1f);

        //generate starting rotation of asteroid
        gameObject.transform.rotation = new Quaternion(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));

        //randomise rotation direction
        OrbitRotation = (ROTATION)(Random.Range(0, 2));

        //randomise whether the asteroid is chasing
        int rand = Random.Range(1, 6);
        switch (rand)
        {
            case 1:
                Chasing = false;
                break;
            case 2:
                Chasing = true;
                break;
            case 3:
                Chasing = false;
                break;
            case 4:
                Chasing = true;
                break;
            case 5:
                Chasing = false;
                break;
        }

        //if applicable, give asteroid a target
        if (Chasing)
        {
            List<GeneralObject> PopulationCentres = new List<GeneralObject>();
            GeneralObject[] Objects = (GeneralObject[])FindObjectsOfType(typeof(GeneralObject));

            for (int i = 0; i < Objects.Length; i++)
            {
                if (System.Convert.ToInt64(Objects[i].Population) > 0) PopulationCentres.Add(Objects[i]);
            }

            Target = PopulationCentres[Random.Range(0, PopulationCentres.Count)];
        }
    }

    /// <summary>
    /// Derived code to be executed in the superclass (GeneralObject) FixedUpdate() method
    /// </summary>
    override public void DerivedFixedUpdate()
    {
        Rotate();
        if (Chasing) Move();
    }

    /// <summary>
    /// Rotates the asteroidal object with the class's specified rotation speed and rotation direction
    /// </summary>
    private void Rotate()
    {
        if (OrbitRotation == ROTATION.clockwise) transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.down, RotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Moves the asteroidal object towards its targetr
    /// </summary>
    private void Move()
    {
        Vector3 distance = (Target.transform.position - transform.position).normalized;
        transform.position = transform.position + distance * 10f * Time.deltaTime;
    }

    /// <summary>
    /// Gets the size of the asteroidal object
    /// </summary>
    /// <returns>Returns a float of the diametre of the asteroid</returns>
    override public float GetSize() { return GetComponent<MeshFilter>().mesh.bounds.extents.x * GetComponent<Transform>().localScale.x; }
}
