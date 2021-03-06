﻿/*
    purpose: variables object for player/probe
    usage: only used on probe entities
*/

using UnityEngine;

public class ProbeVariables : GeneralVariables
{
    //probe module stats
    private float CommunicationDistance = 10000.0f; //distance the probe can communicate over
    private float Fuel = 10000.0f; //range the probe can travel before being stranded
    private int PowerGenerationBonus = 0; //bonus from power generation
    private int SensorCapacityBonus = 0; //bonus from sensor capacity

    //probe tiering stats
    private int CATier = 1; //communications array tier
    private int FTTier = 1; //fuel tank tier
    private int PGTier = 1; //power generator tier
    private int SSTier = 1; //sensor suite tier
    private int OverallTier = 1; //overall tier of probe

    //other stats
    private float Speed = 0;
    private int Materials = 0;

    void Update()
    {
        //purpose: ensures overall tier is correct
        OverallTier = (int)System.Math.Round((double)((CATier + FTTier + PGTier + SSTier) / 4));
    }

    override public void DerivedFixedUpdateTasks()
    {
        //purpose: get probe's velocity
        Speed = (float)(GetComponent<Rigidbody>().velocity.magnitude * 3.6); //multiplying result by 3.6 converts m/s to KPH
    }

    //variable getters
    public float GetCommunicationDistance() { return CommunicationDistance; }
    public float GetFuel() { return Fuel; }
    public int GetFuelRounded() { return (int)System.Math.Round(Fuel); }
    public float GetPowerGeneration() { return PowerGenerationBonus; }
    public float GetSensorCapacity() { return SensorCapacityBonus; }
    public int GetTier() { return OverallTier; }
    public float GetSpeed() { return Speed; }
    public int GetMaterialsCount() { return Materials; }

    //variable setters
    public void SetFuel(float newFuelVal) { Fuel = newFuelVal; }
    public void SetCommunicationArrayTier(int newCAVal) { CATier = newCAVal; }
    public void SetFuelTankTier(int newFTVal) { FTTier = newFTVal; }
    public void SetPowerGeneratorTier(int newPGVal) { PGTier = newPGVal; }
    public void SetSensorSuiteTier(int newSSVal) { SSTier = newSSVal; }
}