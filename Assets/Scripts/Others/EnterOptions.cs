using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterOptions : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject AudioPanel;

    // Use this for initialization
    void Start () {
        this.GetComponent<Button>().onClick.AddListener(Clicked);
	}
	
	// Update is called once per frame
	void Clicked() {
        MainMenuPanel.GetComponent<Animator>().SetTrigger("Close");
        MainMenuPanel.GetComponent<CanvasGroup>().interactable = false;
        OptionsPanel.GetComponent<Animator>().SetTrigger("Open");
        AudioPanel.GetComponent<Animator>().SetTrigger("Open");
        OptionsPanel.GetComponent<CanvasGroup>().interactable = true;
        AudioPanel.GetComponent<CanvasGroup>().interactable = true;
    }
}
