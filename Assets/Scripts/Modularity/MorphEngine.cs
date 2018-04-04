using UnityEngine;

/// <summary>
/// Allows tier changing and scale transformations to be applied to the probe
/// </summary>
public class MorphEngine : MonoBehaviour
{
    /// <summary>
    /// Local reference of probe's object class
    /// </summary>
    private ProbeObject probe;

    /// <summary>
    /// Division factor to alter morphing factor calculations
    /// </summary>
    [SerializeField]
    private int MorphModifier = 4;

    void Start() { probe = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeObject>(); }    

    void Update() { DebugMorph(); }

    /// <summary>
    /// Sets the tier of the probe
    /// </summary>
    /// <param name="tier">Tier in which the probe will be set to (defaulted as 1)</param>
    void SetTier(float tier = 1)
    {
        //if specified change is the the same as the current tier, ignore attempting to morph
        if (probe.GetTier() == tier) return;

        //calculate morphFactor (scale in which certain probe features will be)
        float morphFactor = 1f + (float)(tier / MorphModifier);
        probe.SetTier((int)tier);

        //call for the application of the scale changes
        ApplyMorph(morphFactor);
    }

    /// <summary>
    /// Applies a scale transform to tagged parts of the probe
    /// </summary>
    /// <param name="morphFactor">New scale</param>
    void ApplyMorph(float morphFactor)
    {
        GameObject.FindGameObjectWithTag("ProbePylon").transform.localScale = new Vector3(morphFactor, morphFactor, 1);
        GameObject.FindGameObjectWithTag("ProbeAerial").transform.localScale = new Vector3(morphFactor, morphFactor, morphFactor);
        GameObject.FindGameObjectWithTag("ProbeEngine").transform.localScale = new Vector3(morphFactor, morphFactor, morphFactor);
        GameObject.FindGameObjectWithTag("Gun").transform.localScale = new Vector3(morphFactor, morphFactor, morphFactor);
    }

    /// <summary>
    /// Allows testing of the morph with number keys 1 to 4 (TO BE DISABLED IN THE FUTURE)
    /// </summary>
    void DebugMorph()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            SetTier(1);
        else if (Input.GetKey(KeyCode.Alpha2))
            SetTier(2);
        else if (Input.GetKey(KeyCode.Alpha3))
            SetTier(3);
        else if (Input.GetKey(KeyCode.Alpha4))
            SetTier(4);
    }
}
