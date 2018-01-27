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
        private string body; //name of body this result was produced with

        public GravimetricResult(Vector3 newForce, float newDistance, string newBody = "")
        {
            //purpose: class constructor

            force = newForce;
            distance = newDistance;
            body = newBody;
        }

        //getters
        public Vector3 GetForce() { return force; }
        public float GetDistanceBetweenObjectAndBody() { return distance; }
        public string GetBodyName() { return body; }
    };
}
