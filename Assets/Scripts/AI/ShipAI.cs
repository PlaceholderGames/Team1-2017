/*
    purpose: Solar Ship artificial intelligence engine
    usage: attached to Solar Ships that are expected to be interactive
*/

using Assets.Scripts.Containers;
using UnityEngine;

namespace Assets.Scripts.AI
{
    class ShipAI : MonoBehaviour
    {
        //variables for controlling the delta time between events
        public int deltaMin = 0; //minimum time of event
        public int deltaMax = 1; //maximum time of event

        //variables for overriding the AI to perform a certain follow task
        public GameObject overrideObjective; //specified override objective for an object to travel to

        //object effect references so that they can be controlled by AI actions
        public GameObject lensflare; //reference to lens flare
        public GameObject particles; //reference to particles

        //variables for how the object is supposed to interact
        public float maxSpeed = 10f; //speed limit for object
        public float maxRotate = 0.1f; //the amount the object can rotate once moving

        private AIEvent currentEvent; //current event of this AI

        void Start() { currentEvent = CreateEvent(); }

        void FixedUpdate() { if (currentEvent.Poll()) currentEvent = CreateEvent(); }

        private AIEvent CreateEvent()
        {
            if (overrideObjective == null)
            {
                int randAction = Random.Range(0, 2);
                int randDuration = Random.Range(deltaMin, deltaMax);

                if (randAction == 0) //stationary
                {
                    return new AIEvent(gameObject, particles, lensflare, Action.Stationary, null, 0, 0, randDuration);
                }
                else if (randAction == 1) //random travel
                {
                    GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //all planets in scene
                    int rand = Random.Range(0, planets.Length); //random integer to select planet with
                    return new AIEvent(gameObject, particles, lensflare, Action.Travel, planets[rand], maxSpeed, maxRotate);
                }
                else if (randAction == 2) //follow player
                {
                    return new AIEvent(gameObject, particles, lensflare, Action.Travel, GameObject.FindGameObjectWithTag("Player"), maxSpeed, maxRotate, randDuration);
                }
            }
            else return new AIEvent(gameObject, particles, lensflare, Action.Travel, overrideObjective, maxSpeed, maxRotate); //engage on override objective
            return new AIEvent(gameObject, particles, lensflare, Action.Stationary); //default event is long stationary
        }
    }
}