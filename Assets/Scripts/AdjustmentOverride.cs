using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustmentOverride : MonoBehaviour
{
	public float fltStep = 1;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
		{
			transform.position = new Vector3(transform.position.x + fltStep, transform.position.y, transform.position.z);
		}
		else if (Input.GetKeyDown (KeyCode.D))
		{
			transform.position = new Vector3(transform.position.x - fltStep, transform.position.y, transform.position.z);
		}
	}
}
