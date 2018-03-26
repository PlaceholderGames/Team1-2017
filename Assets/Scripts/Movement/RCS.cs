using UnityEngine;

/// <summary>
/// DO NOT USE
/// Detects eradic movement and stablises ship
/// </summary>
public class RCS : MonoBehaviour
{
    /// <summary>
    /// Reference for ship the RCS has to stablise
    /// </summary>
    private Transform ship;

    /// <summary>
    /// Stores the last rotational data of the ship
    /// </summary>
    private Quaternion previous;

    void Start() { ship = gameObject.GetComponent<Transform>(); }

    void FixedUpdate()
    {
        //compile normalised rotation
        Quaternion normalisedRotation = new Quaternion();
        normalisedRotation.x = StabliseAxis(ship.rotation.x, previous.x);
        normalisedRotation.y = StabliseAxis(ship.rotation.y, previous.y);
        normalisedRotation.z = StabliseAxis(ship.rotation.z, previous.z);

        //exchange rotations
        previous = ship.rotation;
        ship.rotation = normalisedRotation;
    }

    /// <summary>
    /// Attempts to stablise an rotational axis
    /// </summary>
    /// <param name="current">Current axis value</param>
    /// <param name="previous">Previous axis value</param>
    /// <returns></returns>
    private float StabliseAxis(float current, float previous)
    {
        Debug.Log("Current " + current);
        Debug.Log("Previous " + previous);
        //IMPLEMENT KALMAN FILTER
        float difference = current - previous;
        if (difference < -0.01 || difference > 0.01) return previous;
        else return current;
    }
}