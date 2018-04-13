using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameKeyListener : MonoBehaviour
{
    void Update() { if (Input.GetKey(KeyCode.Alpha5)) SceneManager.LoadScene(1); }
}