using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BodyObjects

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject asteroid;
    public int numberOfAsteroids;
    public int min, max;

    public BodyVariables body;


    void Start()
    {
        PlaceAsteroids();
    }

    void PlaceAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Instantiate(asteroid, GeneratedPosition(), Quaternion.identity);
        }
    }
    Vector3 GeneratedPosition()
    {
        int x, y, z;
        x = UnityEngine.Random.Range(min, max);
        y = UnityEngine.Random.Range(min, max);
        z = UnityEngine.Random.Range(min, max);
        return new Vector3(x, y, z);
    }
}
	