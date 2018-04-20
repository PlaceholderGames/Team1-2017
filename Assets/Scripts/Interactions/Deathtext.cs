using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deathtext : MonoBehaviour
{

    private ProbeObject probe;
    public Text deathlabel;
    // Use this for initialization
    void Start()
    {
        probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (probe == null)
        {
            Displaydeathtext();
        }
    }

    void Displaydeathtext()
    {
        deathlabel.text = "You Died.";
    }
}

