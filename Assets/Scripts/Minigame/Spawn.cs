using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] objects;
    public Vector3 center;
    public Vector3 size;
    int B = -320;
	// Use this for initialization
	void Start ()
    {
        int Difficulty = 3;
        // Need to get a code that grabs the value of the collison, cant do this until internet is back
        if (Difficulty == 1)
        {
            SpawnTunnelEasy();
            for (int x = 8; x > 0; x--)
                SpawnObjectEasy();
        }
        else if (Difficulty == 2)
        {
            SpawnTunnelMedium();
            for (int x = 16; x > 0; x--)
                SpawnObjectMedium();
        }
        else if (Difficulty == 3)
        {
            SpawnTunnelHard();
            for (int x = 24; x > 0; x--)
                SpawnObjectHard();
        }

    }
	
	// Update is called once per frame
	void Update ()
    {

      

    }
  


    public void DestroyAllGameObjects()
    {
       
    }
    public void SpawnObjectEasy()
    {
        B = B + 60;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), B, Random.Range(-size.z / 2, size.z / 2));
        int A = Random.Range(3,6);

        Instantiate(objects[A], pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
    public void SpawnObjectMedium()
    {
        B = B + 60;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), B, Random.Range(-size.z / 2, size.z / 2));
        int A = Random.Range(3, 6);

        Instantiate(objects[A], pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
    public void SpawnObjectHard()
    {
        B = B + 60;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), B, Random.Range(-size.z / 2, size.z / 2));
        int A = Random.Range(3, 10);

        Instantiate(objects[A], pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
    }



    public void SpawnTunnelEasy()
    {
        Vector3 pos = center;
        Instantiate(objects[0]);
        Instantiate(objects[1], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(objects[2], new Vector3(0, 500, 0), Quaternion.Euler(0, Random.Range(0, 360), 180));
    }
    public void SpawnTunnelMedium()
    {
        Vector3 pos = center;
        Instantiate(objects[0]);
        Instantiate(objects[1], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(objects[2], new Vector3(0, 1000, 0), Quaternion.Euler(0, Random.Range(0, 360), 180));
        for (int i = 500; i > 0; i = i - 500)
            Instantiate(objects[0], new Vector3(0, i, 0), Quaternion.identity);
    }
    public void SpawnTunnelHard()
    {
        Vector3 pos = center;
        Instantiate(objects[0]);
        Instantiate(objects[1], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(objects[2], new Vector3(0, 1500, 0), Quaternion.Euler(0, Random.Range(0, 360), 180));
        for (int i = 1000; i > 0; i = i - 500)
        Instantiate(objects[0], new Vector3(0, i, 0), Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
