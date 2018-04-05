using UnityEngine;

/// <summary>
/// Variables class for Probe objects
/// </summary>
public class ProbeObject : GeneralObject
{
    /// <summary>
    /// Fuel that dictates the probe's range
    /// </summary>
    private float Fuel = 10000.0f;

    /// <summary>
    /// 
    /// </summary>
    private float Bonus = 1f;

    /// <summary>
    /// Overall tier of the probe
    /// </summary>
    private int Tier = 1;

    /// <summary>
    /// Amount of materials the probe has onboard
    /// </summary>
    private int Materials = 0;

    /// <summary>
    /// Dervided code to be executed in the superclass (GeneralObject) Start() method
    /// </summary>
    override public void DerivedStart() { Tier = 1; }

    override public void DerivedFixedUpdate() { DebugMorph(); }

    /// <summary>
    /// Allows testing of the morph with number keys 1 to 4 (TO BE DISABLED IN THE FUTURE)
    /// </summary>
    private void DebugMorph()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            ProbeTransformer.TransformT1();
        else if (Input.GetKey(KeyCode.Alpha2))
            ProbeTransformer.TransformT2();
        else if (Input.GetKey(KeyCode.Alpha3))
            ProbeTransformer.TransformT3();
        else if (Input.GetKey(KeyCode.Alpha4))
            ProbeTransformer.TransformT4();
    }

    /// <summary>
    /// Gets the remaining fuel  
    /// </summary>
    /// <returns>Returns a float of the raw fuel value</returns>
    public float GetFuel() { return Fuel; }

    /// <summary>
    /// Gets the approximately remaining fuel 
    /// </summary>
    /// <returns>Returns an integer of a rounded fuel value</returns>
    public int GetFuelRounded() { return (int)System.Math.Round(Fuel); }

    /// <summary>
    /// Gets the bonus value for affecting the rewards from drilling
    /// </summary>
    /// <returns>Returns an integer of the bonus value due to the probe's tier</returns>
    public float GetBonus() { return Bonus; }

    /// <summary>
    /// Gets the current overall tier of the probe
    /// </summary>
    /// <returns>Returns an integer of the probe's current tier</returns>
    public int GetTier() { return Tier; }

    /// <summary>
    /// Gets the materials held onboard the probe
    /// </summary>
    /// <returns>Returns an integer of the amount of materials currently being stored onboard the probe</returns>
    public int GetMaterialsCount() { return Materials; }

    /// <summary>
    /// Sets the probe's remaining fuel
    /// </summary>
    /// <param name="newFuel">Amount of fuel to be set</param>
    public void SetFuel(float newFuel) { Fuel = newFuel; }

    /// <summary>
    /// Sets the probe's tier
    /// </summary>
    /// <param name="newTier">Tier value to be set</param>
    public void SetTier(int newTier) { Tier = newTier; }

    /// <summary>
    /// Sets the probe's onboard material
    /// </summary>
    /// <param name="newMaterials">Materials value to be set</param>
    public void SetMaterialsCount(int newMaterials) { Materials = newMaterials; }
}