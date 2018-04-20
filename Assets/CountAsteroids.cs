using UnityEngine;

public class CountAsteroids : MonoBehaviour
{
	void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Asteroids: " + GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }
}