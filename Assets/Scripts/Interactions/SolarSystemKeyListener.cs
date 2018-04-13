using UnityEngine;
using UnityEngine.SceneManagement;

public class SolarSystemKeyListener : MonoBehaviour
{
	void Update () { if (Input.GetKey(KeyCode.Alpha5)) SceneManager.LoadScene(2); }
}