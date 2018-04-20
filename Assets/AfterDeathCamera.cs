using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterDeathCamera : MonoBehaviour {

    public Camera DeathCamera;
    private ProbeObject probe;
	// Use this for initialization
	void Start () {
        probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>();
        DeathCamera.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(probe == null)
        {
            DeathCamera.enabled = true;
        }
		
	}
}
