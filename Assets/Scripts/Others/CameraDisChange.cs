using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDisChange : MonoBehaviour {

    public GameObject mainCamera;

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, this.GetComponent<Slider>().value * (-1));
    }


}
