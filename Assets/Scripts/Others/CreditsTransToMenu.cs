using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTransToMenu : MonoBehaviour
{

    public GameObject MainMenuPanel;

    public void CreditsEnd()
    {
        MainMenuPanel.SetActive(true);
        MainMenuPanel.GetComponent<Animator>().SetTrigger("Open");
        MainMenuPanel.GetComponent<CanvasGroup>().interactable = true;
        this.gameObject.SetActive(false);

    }
}