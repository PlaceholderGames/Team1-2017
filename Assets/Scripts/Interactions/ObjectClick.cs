/*
    purpose: handles when player clicks on an object
    usage: attached to probe
*/

using UnityEngine;
using UnityEngine.UI;

public class ObjectClick : MonoBehaviour
{
    public GameObject selectedObjectName; //reference to selected object's name label object
    public GameObject selectedObjectPopulation; //reference to selected object's population label object
    private float untilTimeout = 0.0f; //used for timeout for when the labels should be cleared after clicking an object

    void Update()
    {
        //check for mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rcHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rcHit))
            {
                //display object's name
                selectedObjectName.GetComponent<Text>().text = "Selected: " + rcHit.collider.transform.name;

                //display object's population if possible
                Debug.Log(rcHit.collider.GetComponent<GeneralVariables>().Population);
                if (rcHit.collider.GetComponent<GeneralVariables>().Population != "0")
                    selectedObjectPopulation.GetComponent<Text>().text = "Population: " + string.Format("{0:n0}", rcHit.collider.GetComponent<GeneralVariables>().GetPopulation());
                else selectedObjectPopulation.GetComponent<Text>().text = "";

                //start timeout countdown
                untilTimeout = 3;
            }
            else
            {
                selectedObjectName.GetComponent<Text>().text = "";
                selectedObjectPopulation.GetComponent<Text>().text = "";
                untilTimeout = 0;
            }
        }

        //manage timeout if applicable
        if (untilTimeout > 0) untilTimeout -= Time.deltaTime;
        else if (untilTimeout <= 0)
        {
            selectedObjectName.GetComponent<Text>().text = "";
            selectedObjectPopulation.GetComponent<Text>().text = "";
            untilTimeout = 0;
        }
    }
}