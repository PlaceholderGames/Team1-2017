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
        public float maxTravelSpeed = 1000f;
        public float focusRadius = 5000; //how far from the current location can the object focus on

        private GeneralVariables currentFocusObj; //stores the thing that object is currently focused on

        override public void DerivedStart() { StartEvent(); }

        override public void DerivedFixedUpdate()
        {
            switch (currentAction) //maintain event processing
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

        override public void StartEvent()
        {
            countdownUntilFinish = Random.Range(deltaMin, deltaMax);
            int probRand = Random.Range(0, 3);
            if (probRand == 0)
            {
                currentAction = Action.Stationary;
            }
            else if (probRand == 1)
            {
                currentAction = Action.RandomTravel;
                GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //all planets in scene
                int rand = Random.Range(0, planets.Length);
                currentFocusObj = planets[rand].GetComponent<GeneralVariables>();
                Follow();
            }
            else if (probRand == 2)
            {
                currentAction = Action.FollowPlayer;
                currentFocusObj = GameObject.FindGameObjectWithTag("Player").GetComponent<ProbeVariables>();
                Follow();
            }
        }

        private void Follow()
        {
            //purpose: directs object towards current focus

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentFocusObj.GetPosition() - transform.position), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * (maxTravelSpeed * speedComparedToPlayer) * Time.deltaTime;
        }
    }
}