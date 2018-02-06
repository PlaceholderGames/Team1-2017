/*
    purpose: Solar Ship artificial intelligence engine
    usage: attached to Solar Ships that are expected to be interactive
*/

using UnityEngine;

namespace Assets.Scripts.AI
{
    class ShipAI : GeneralAI
    { 
        //variables for how the object is supposed to interact
        public float speedComparedToPlayer = 1f; //speed the object's follows the player at (where 1f is match speed)
        public float rotationSpeed = 1f; //the amount the object can rotate once moving
        public float maxTravelSpeed = 100f; //speed limit for object

        private GeneralVariables currentFocusObj; //stores the thing that object is currently focused on


        override public void DerivedStart()
        {
            StartEvent();
            if (overrideObjective != null) currentFocusObj = overrideObjective; //if override is specified, make override the focus for the object
        }

        override public void DerivedFixedUpdate()
        {
            if (overrideObjective == null) //process current event if no override is specified
            {
                switch (currentAction) //maintain event processing by executing the action required for event
                {
                    case Action.None:
                        StartEvent();
                        break;
                    case Action.Stationary:
                        break;
                    case Action.RandomTravel:
                        Follow();
                        break;
                    case Action.FollowPlayer:
                        Follow();
                        break;
                }
            }
            else Follow(); //if overriden, follow to move to override objective
        }

        override public void StartEvent()
        {
            //randomly selects an event

            countdownUntilFinish = Random.Range(deltaMin, deltaMax); //randomise time period of event
            int probRand = Random.Range(0, 3); //randomise event slector

            if (probRand == 0) //stationary
            {
                currentAction = Action.Stationary;
                lensflare.GetComponent<LensFlare>().enabled = false;
                particles.GetComponent<ParticleSystem>().Stop();
            }
            else if (probRand == 1) //random travel
            {
                currentAction = Action.RandomTravel;
                GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //all planets in scene
                int rand = Random.Range(0, planets.Length);
                currentFocusObj = planets[rand].GetComponent<GeneralVariables>();
                countdownUntilFinish = 960; //override random number for countdown to allow the object to have a reasonable change of arrival
                lensflare.GetComponent<LensFlare>().enabled = true;
                particles.GetComponent<ParticleSystem>().Play();
                Follow();
            }
            else if (probRand == 2) //follow player
            {
                currentAction = Action.FollowPlayer;
                currentFocusObj = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeVariables>();
                lensflare.GetComponent<LensFlare>().enabled = true;
                particles.GetComponent<ParticleSystem>().Play();
                Follow();
            }
        }

        private void Follow()
        {
            //purpose: directs object towards current focus

            //translate object
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentFocusObj.GetPosition() - transform.position), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * (maxTravelSpeed * speedComparedToPlayer) * Time.deltaTime;

            //check if object has reached its destination
            Vector3 different = currentFocusObj.GetPosition() - GetComponent<GeneralVariables>().GetPosition(); //work out direction between both objects
            if ((different.magnitude - (currentFocusObj.GetSize()) * 2) <= 0) EndEvent();
        }
    }
}