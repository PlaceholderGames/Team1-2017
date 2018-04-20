using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hemisphere End(Clone)")
        {
            GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

            for (int i = 0; i < GameObjects.Length; i++)
            {
                Destroy(GameObjects[i]);
            }
            SceneManager.LoadScene("Drill Minigame");
        }
    }
}
