/// <summary>
/// NU GRAVITY script
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravimetrics : MonoBehaviour
{
    Vector3 GetMovementGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when on the move
        //pre-condition: method is called when the object is moving and is within range of a planet

        //1) declare Attraction vector3
        //2) get closest body
        //3) calculate relative distance
        //4) calculate force needed to adjust its position
        //5) translate force into Attraction vector3
        //6) return Attraction vector3

        Vector3 Attraction = new Vector3(0.0f, 0.0f, 0.0f);
        return Attraction;
    }

    void ApplyStationaryGravity()
    {
        //purpose: calculates satellite's attraction towards a planetary body when stationary

        //1) get closest body
        //2) calculate relative distance
        //3) calculate force 
        //4) push object towards body directly
    }
    
}
