using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameEntry : MonoBehaviour {

    public GameObject miniGameLabelTxt;

    // Update is called once per frame
    void Update()
    {
        //calculate the direction between the two objects
        Vector3 direction = gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;


        //compare the magnitude of the direction (distance) to some sort of trigger radius
        if (direction.magnitude <= 150)
        {
            miniGameLabelTxt.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {

                StartCoroutine(LoadScene());
            }
        }
        else
            miniGameLabelTxt.SetActive(false);



    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
