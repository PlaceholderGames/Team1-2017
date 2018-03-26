using UnityEngine;

/// <summary>
/// Encapulsation for gravity properties from a gravity calculation
/// </summary>
public class GravimetricResult
{
    /// <summary>
    /// Force due to gravity at time of calculation
    /// </summary>
    private Vector3 force;

    /// <summary>
    /// Distance between probe and planetary body at time of calculation
    /// </summary>
    private float distance;

    /// <summary>
    /// Name of body this result was produced with
    /// </summary>
    private string body;

    public GravimetricResult(Vector3 newForce, float newDistance, string newBody = "")
    {
        force = newForce;
        distance = newDistance;
        body = newBody;
    }

    /// <summary>
    /// Gets the force due to gravity
    /// </summary>
    /// <returns>Returns a Vector3 of the raw force numbers without magnitude being calculated</returns>
    public Vector3 GetForce() { return force; }

    /// <summary>
    /// Gets distance between probe and body
    /// </summary>
    /// <returns>Returns float of the distance magnitude between the two objects used to calculate the force numbers</returns>
    public float GetDistanceBetweenObjectAndBody() { return distance; }

    /// <summary>
    /// Gets the name of the plantery body this force calculation was made from
    /// </summary>
    /// <returns>Returns string of the planet's name</returns>
    public string GetBodyName() { return body; }
};