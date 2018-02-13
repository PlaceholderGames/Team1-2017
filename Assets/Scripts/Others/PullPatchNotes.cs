using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PullPatchNotes : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://github.com/16009797/MINE/files/1720675/PatchNotes.txt");
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
            GetComponent<Text>().text = "Error getting patch notes from server";
        }
        else
        {
            // show results as text
            GetComponent<Text>().text = www.downloadHandler.text;

            // Or retreive results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}

