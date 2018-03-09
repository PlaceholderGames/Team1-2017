using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDesiredPanelInOptions : MonoBehaviour {

    public Button clickedButton;
    public Button otherButtonOne;
    public Button otherButtonTwo;
    public GameObject connectedPanel;
    public GameObject otherPanelOne;
    public GameObject otherPanelTwo; 


	// Use this for initialization
	void Start () {
        clickedButton.GetComponent<Button>().onClick.AddListener(Clicked);
    }


    // Update is called once per frame
    void Clicked () {

        if (otherPanelOne.GetComponent<CanvasGroup>().alpha == 1)
       {

            otherPanelOne.GetComponent<Animator>().SetTrigger("Close");

          
            otherPanelOne.GetComponent<CanvasGroup>().interactable = false;

            otherButtonOne.interactable = true;

            connectedPanel.SetActive(true);
            connectedPanel.GetComponent<CanvasGroup>().interactable = true;
            connectedPanel.GetComponent<Animator>().SetTrigger("Open");
            clickedButton.interactable = false;
        }
        else if (otherPanelTwo.GetComponent<CanvasGroup>().alpha == 1)
        {
            otherPanelTwo.GetComponent<Animator>().SetTrigger("Close");
         
        
            otherPanelTwo.GetComponent<CanvasGroup>().interactable = false;
            otherButtonTwo.interactable = true;

            connectedPanel.SetActive(true);
            connectedPanel.GetComponent<CanvasGroup>().interactable = true;
            connectedPanel.GetComponent<Animator>().SetTrigger("Open");
            clickedButton.interactable = false;
        }
    }

    IEnumerator DoAnimation()
    {
        Debug.Log("This happens 2 seconds later. Tada.");
        
        yield return new WaitForSeconds(300f); // wait for two seconds.
        
    }
}
