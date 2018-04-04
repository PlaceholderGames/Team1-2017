/*
    purpose: variables class for probes
    usage: only used on probe entities
*/

using UnityEngine;

public class ProbeObject : GeneralObject
{
    //probe module stats
    private float CommunicationDistance = 10000.0f; //distance the probe can communicate over
    private float Fuel = 10000.0f; //range the probe can travel before being stranded

    //other stats
    private int Tier = 1; //overall tier of probe
    private int Munitions = 100; //amount of projectiles the probe can hold
    private int Materials = 0; //amount of materials the probe is carrying

    //override Start to allow ProbeObject to calculate its average tier
    override public void DerivedStart() { Tier = 1; } 

    //variable getters
    public float GetCommunicationDistance() { return CommunicationDistance; }
    public float GetFuel() { return Fuel; }
    public int GetFuelRounded() { return (int)System.Math.Round(Fuel); }
    public float GetPowerGeneration() { return 0; }
    public float GetSensorCapacity() { return 0; }
    public int GetTier() { return Tier; }
    public int GetMaterialsCount() { return Materials; }
    public int GetMunitionsRemaining() { return Munitions; }

    //variable setters
    public void SetFuel(float newFuelVal) { Fuel = newFuelVal; }
    public void SetTier(int newTier) { Tier = newTier; }
    public void SetMaterialsCount(int newMaterials) { Materials = newMaterials; }
    public void SetMunitionsRemaining(int newMunitions) { Munitions = newMunitions; }
}