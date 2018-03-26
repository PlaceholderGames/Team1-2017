using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles when a player clicks on an object
/// </summary>
public class ObjectClick : MonoBehaviour
{
    /// <summary>
    /// Reference to selected object's name label object
    /// </summary>
    public GameObject selectedObjectName;

    /// <summary>
    /// Reference to selected object's population label object
    /// </summary>
    public GameObject selectedObjectPopulation;

    /// <summary>
    /// Timeout for when the labels should be cleared after clicking an object
    /// </summary>
    private float untilTimeout = 0.0f;

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
                if (rcHit.collider.GetComponent<GeneralObject>().Population != "0")
                    selectedObjectPopulation.GetComponent<Text>().text = "Population: " + string.Format("{0:n0}", rcHit.collider.GetComponent<GeneralObject>().GetPopulation());
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