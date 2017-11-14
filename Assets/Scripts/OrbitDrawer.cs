using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDrawer : MonoBehaviour
{
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lineRenderer.SetColors(Color.black, Color.black);

    }
}
