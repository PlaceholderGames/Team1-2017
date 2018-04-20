using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Restart : MonoBehaviour
{
    public ProbeObject Probe;
    public GameObject fadeBlack;
    public GameObject deadText;

    void Start()
    {
        Probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();



    }
    void Update()
    {
        if (Probe == null)
        {
            deadText.SetActive(true);
            this.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.GetComponent<Button>().onClick.AddListener(Restartgame);
        }
    }

    void Restartgame()
    {
        deadText.SetActive(false);
        fadeBlack.GetComponent<Animator>().SetTrigger("Fade");
       
    }

}

