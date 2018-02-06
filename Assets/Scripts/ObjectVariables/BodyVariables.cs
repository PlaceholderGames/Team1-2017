/*
    purpose: variables object for planetary bodies
    usage: only used on planets and asteroids
*/

using UnityEngine;

public class BodyVariables : GeneralVariables
{
    public float GravimetricStrength = 1.0f; //gravimetric strength outputted by entity (used as a factoring variable)
    public float GetDiameter() { return GetComponent<MeshFilter>().mesh.bounds.extents.x * 2; }
}