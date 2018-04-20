using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    float timeRemaining = 80;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        gameObject.GetComponent<Text>().text = timeRemaining.ToString();
        if (timeRemaining > 0)
        {
            GUI.Label(new Rect(100, 100, 200, 100), "Time Remaining : " + timeRemaining);
        }
        else if (timeRemaining <= 0)
        {
            GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

            for (int i = 0; i < GameObjects.Length; i++)
            {
                Destroy(GameObjects[i]);
            }
           // SceneManager.LoadScene("Whatever main game is called");
        }
    }

}
