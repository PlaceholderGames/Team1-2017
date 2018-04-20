using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Restart : MonoBehaviour
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
            gameObject.GetComponent<Button>().onClick.AddListener(Restartgame);
        }
    }

    void Restartgame()
    {
        fadeBlack.GetComponent<Animator>().SetTrigger("Fade");
    }

}

