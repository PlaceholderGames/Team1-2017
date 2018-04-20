using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullPushSettings : MonoBehaviour {

    public static int gFOV = 75;
    public static int gCamDis = -10;
    public static bool gLenFlare = true;

    public Slider FOVSlider;
    public Slider CamDisSlider;
    public Toggle LenFlareToggle;

    public GameObject mainCamera;

    // Use this for initialization
    void Start () {

        FOVSlider.value = gFOV;
        CamDisSlider.value = gCamDis*(-1);
        LenFlareToggle.isOn = gLenFlare;

        
		
	}
	
	// Update is called once per frame
	void Update () {
        gFOV = (int)FOVSlider.value;
        gCamDis = (int)CamDisSlider.value * (-1);
        gLenFlare = LenFlareToggle.isOn;
	}



}
