using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject asteroid;
    public int numberOfAsteroids = 1;
    public int min, max;

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
        x = Random.Range(min, max);
        y = Random.Range(min, max);
        z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }
}