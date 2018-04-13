using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coordinate : MonoBehaviour {

    private ProbeObject probe;
    // Use this for initialization

    public GameObject coordLabel;

	void Start () {
        probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
    }
	
	// Update is called once per frame
	void Update () {
        coordLabel.GetComponent<Text>().text = "X: " + probe.GetPosition().x + "\nY:" + probe.GetPosition().y + "\nZ: " + probe.GetPosition().z;
    }
    
}
