/*
    purpose: provides encapulsation for gravity properties from a gravity calculation
    usage: internally when gravity needs applying
*/

using UnityEngine;

namespace Assets.Scripts.Others
{
    public class GravimetricResult
    {
        private Vector3 force; //force due to gravity at time of calculation
        private float distance; //distance between probe and planetary body at time of calculation

        public GravimetricResult(Vector3 newForce, float newDistance)
        {
            //purpose: class constructor

            force = newForce;
            distance = newDistance;
        }

        //getters
        public Vector3 GetForce() { return force; }
        public float GetDistanceBetweenProbeAndBody() { return distance; }
    };
}
