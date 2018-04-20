using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public ProbeObject Probe;
    public GameObject fadeBlack;

    void Start()
    {
        Probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
    }

    void Update()
    {
        if (Probe == null)
        {
            this.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.GetComponent<Button>().onClick.AddListener(Quitgame);
        }
    }

    void Quitgame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
}
