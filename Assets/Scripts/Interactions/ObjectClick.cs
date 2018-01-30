/*
    purpose: handles when player clicks on an object
    usage: attached to probe
*/

using UnityEngine;
using UnityEngine.UI;

public class ObjectClick : MonoBehaviour
{
    public GameObject selectedObjectLabel; //reference to selected object label object

    void Update()
    {
        //check for mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rcHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rcHit)) selectedObjectLabel.GetComponent<Text>().text = "Selected: " + rcHit.transform.name;
            else selectedObjectLabel.GetComponent<Text>().text = "";
        }
    }
}