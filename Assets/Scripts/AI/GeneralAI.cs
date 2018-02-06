/*
    purpose: generic/base artificial intelligence engine
    usage: abstract - only inherited classes should be used
*/

using UnityEngine;

namespace Assets.Scripts.AI
{
    //enumeration of all possible actions any subclass can do
    enum Action { None, Stationary, RandomTravel, FollowPlayer, Hostile }

    abstract class GeneralAI : MonoBehaviour
    {
        //variables for controlling the delta time between events
        public int deltaMin = 0; //minimum time of event
        public int deltaMax = 1; //maximum time of event

        //current action variables
        protected Action currentAction = Action.None; //current action object is performing
        protected float countdownUntilFinish = 0f; //used for counting down an event's time in execution

        //functions for inherited classes to use so they do not override GeneralAI core functionality
        virtual public void DerivedStart() { } //allows child classes to add start tasks via polymorphism
        virtual public void DerivedFixedUpdate() { } //allows child classes to add update tasks via polymorphism

        void Start() { DerivedStart(); }

        void FixedUpdate()
        {
            if (countdownUntilFinish <= 0f) // check for stale event
             {
                EndEvent();
                StartEvent();
            }
            else
            {
                DerivedFixedUpdate(); //update current event
                countdownUntilFinish -= Time.deltaTime; //decrease time until event expiration
            }
        }

        virtual public void StartEvent() { } //allows child classes to determine event to start via polymorphism

        protected void EndEvent()
        {
            //purpose: resets variables to remove current event

            currentAction = Action.None;
            countdownUntilFinish = 0f;
        }
    }
}