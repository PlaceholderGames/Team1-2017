using UnityEngine;

/// <summary>
/// Allows the probe's mesh to be manipulated based on the probe's tier
/// </summary>
static class ProbeTransformer
{
    /// <summary>
    /// Transforms the probe into Tier 1 appearance
    /// </summary>
    static public void TransformT1()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeEngine").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeEngine")[i].transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeAccelerator").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeAccelerator")[i].transform.localScale = new Vector3(1.35f, 1.35f, 1.35f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel1").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeFuel1")[i].transform.localScale = new Vector3(1f, 1f, 1f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel2").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel3").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeSensor").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeSensor")[i].transform.localScale = new Vector3(0.425f, 0.425f, 0.425f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeWing").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeWing")[i].transform.localScale = new Vector3(1.0f, 0.7f, 1.0f);
    }

    /// <summary>
    /// Transforms the probe into Tier 2 appearance
    /// </summary>
    static public void TransformT2()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeEngine").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeEngine")[i].transform.localScale = new Vector3(0.90f, 0.90f, 0.90f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeAccelerator").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeAccelerator")[i].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel1").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeFuel1")[i].transform.localScale = new Vector3(1f, 1f, 1f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel2").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel3").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeSensor").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeSensor")[i].transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeWing").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeWing")[i].transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
    }

    /// <summary>
    /// Transforms the probe into Tier 3 appearance
    /// </summary>
    static public void TransformT3()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeEngine").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeEngine")[i].transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeAccelerator").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeAccelerator")[i].transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel1").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeFuel1")[i].transform.localScale = new Vector3(1f, 1f, 1f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel2").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel3").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeSensor").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeSensor")[i].transform.localScale = new Vector3(0.475f, 0.475f, 0.475f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeWing").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeWing")[i].transform.localScale = new Vector3(1.0f, 0.9f, 1.0f);

    }

    /// <summary>
    /// Transforms the probe into Tier 4 appearance
    /// </summary>
    static public void TransformT4()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeEngine").Length; i++)

            GameObject.FindGameObjectsWithTag("ProbeEngine")[i].transform.localScale = new Vector3(1f, 1f, 1f);
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeAccelerator").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeAccelerator")[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel1").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeFuel1")[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel2").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectsWithTag("ProbeFuel2")[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeFuel3").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectsWithTag("ProbeFuel3")[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeSensor").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeSensor")[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("ProbeWing").Length; i++)
            GameObject.FindGameObjectsWithTag("ProbeWing")[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}