/*
    purpose: provides encapulsation for gravimetric properties from a gravity calculation
    usage: internally when gravity needs applying
*/

using UnityEngine;

namespace Assets.Scripts.Others
{
    public class GravityProperties
    {
        private Vector3 force; //force due to gravity at time of calculation
        private float distance; //distance between probe and planetary body at time of calculation
        private float drag; //resultant drag due to atmosphere at time of calculation

        public GravityProperties(Vector3 newForce, float newDistance, float newDrag)
        {
            //purpose: class constructor

            force = newForce;
            distance = newDistance;
            drag = newDrag;
        }

        //getters
        public Vector3 GetForce() { return force; }
        public float GetDistanceBetweenProbeAndBody() { return distance; }
        public float GetDragDueToAtmosphere() { return drag; }
    };
}
