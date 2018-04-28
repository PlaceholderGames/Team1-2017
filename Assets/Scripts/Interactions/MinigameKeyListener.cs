using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameKeyListener : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha5))
        {
            GlobalObject.Instance.Position = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>().GetPosition();
            SceneManager.LoadScene(2);
        }
    }
}