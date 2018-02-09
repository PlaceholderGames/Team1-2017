/*
    purpose: detects eradic movement and stablises ship
    usage: probes, ships, space stations etc.
 */

using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class RCS : MonoBehaviour
    {
        private Transform ship; //internal reference for ship the RCS has to stablise
        private Quaternion previous; //stores the last rotational data of the ship[

        void Start() { ship = gameObject.GetComponent<Transform>(); }

        void FixedUpdate()
        {
            //compile normalised rotation
            Quaternion normalisedRotation = new Quaternion();
            normalisedRotation.x = StabliseAxis(ship.rotation.x, previous.x);
            normalisedRotation.y = StabliseAxis(ship.rotation.y, previous.y);
            normalisedRotation.z = StabliseAxis(ship.rotation.z, previous.z);
            normalisedRotation.w = StabliseAxis(ship.rotation.w, previous.w);

            //exchange rotations
            previous = ship.rotation;
            ship.rotation = normalisedRotation;
        }

        private float StabliseAxis(float current, float previous)
        {
            //IMPLEMENT KALMAN FILTER
            float difference = current - previous;
            if (difference < -0.5 || difference > 0.5) return previous;
            else return current;
        }
    }
}