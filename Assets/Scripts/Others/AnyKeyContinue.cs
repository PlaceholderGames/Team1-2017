using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnyKeyContinue : MonoBehaviour
{

    public GameObject MainMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            gameObject.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
