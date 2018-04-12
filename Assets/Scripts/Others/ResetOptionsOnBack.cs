using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetOptionsOnBack : MonoBehaviour
{
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;


    // Use this for initialization
    void Start() {
        this.GetComponent<Button>().onClick.AddListener(Clicked);
       
    }


    // Update is called once per frame
    void Clicked()
    {

        Panel1.GetComponent<CanvasGroup>().alpha = 1.0f;
        Panel2.GetComponent<CanvasGroup>().alpha = 0.0f;
        Panel3.GetComponent<CanvasGroup>().alpha = 0.0f;

        Button1.interactable = false;
        Button2.interactable = true;
        Button3.interactable = true;

        Panel1.GetComponent<Animator>().SetTrigger("Idle");
        Panel2.GetComponent<Animator>().SetTrigger("Idle");
        Panel3.GetComponent<Animator>().SetTrigger("Idle");
        
    }
}
