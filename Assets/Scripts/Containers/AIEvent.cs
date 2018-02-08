/*
    purpose: provides encapulsation for event information for the artificial intelligence to use
    usage: by an AI engine
*/

using UnityEngine;

namespace Assets.Scripts.Containers
{
    //enumeration of all possible actions any subclass can do
    public enum Action { Stationary, Travel, Hostile }

    public class AIEvent : AIEventQueue
    {
        private int eventPriority;
        private GameObject eventAssignee; //the object this event is assigned to
        private GameObject eventFocus; //the object the AI is focused on (used if event is a following type)
        private Action eventAction; //the action this event does
        private float eventDuration; //event's duration
        private float distanceFromFocus; //magnitude of distance between object this Event belongs to and the focus
        private GameObject objectsParticles;
        private GameObject objectsLensFlare;
        private float maxSpeed;
        private float maxRotate;

        public AIEvent(int priority, GameObject assignee, GameObject particles, GameObject lens, Action action, GameObject focus = null, float speed = 10f, float rotation = 0.1f, float duration = float.MaxValue)
        {
            //purpose: class constructor
            //parametres:
                //(priority) the strength of the event
                //(assignee) object this event is assigned too
                //(particles) object that contains object's ParticleSystems
                //(lens) object that contains object's LensFlare
                //(action) the task the AI is expected to perform
                //(focus) any targets the AI is expected to focus on (default null to indicate the event is not focused on anything)
                //(speed) maximum speed the object can travel at (default 10f)
                //(rotation) the degree of rotation the object can do (default 0.1f)
                //(duration) amount of seconds the event is expected to endure for (default at maximum float value)

            eventPriority = priority;
            eventAssignee = assignee;
            eventFocus = focus;
            eventAction = action;
            eventDuration = duration;
            objectsParticles = particles;
            objectsLensFlare = lens;
            maxSpeed = speed;
            maxRotate = rotation;
            if (eventAction == Action.Hostile)
            {
                maxSpeed *= 20;
                maxRotate *= 20;
            }
            if (eventFocus!= null) UpdateDistance();
        }

        public int GetPriority() { return eventPriority; }

        public override bool Poll()
        {
            //purpose: maintains event and returns current status
            //usage: can be used as a independent entity or ideally as a member of the AIEventQueue data structure
            //returning true flags event as complete so that it can be destroyed and a new event enqueued
            //returning false flags event as incomplete and will require further polling to complete

            //update event control variables
            eventDuration -= Time.deltaTime;
            if (eventDuration <= 0) return true; //flag event as complete due to exceeding duration
            if (eventFocus != null) UpdateDistance(); //update distance if a focus target exists

            switch (eventAction) //process event based on eventAction enum
            {
                case Action.Stationary:
                    ToggleEffects(false);
                    return false; //flag event as incomplete
                case Action.Travel:
                    if (eventFocus == null) return true; //flag event for destruction if attempting Follow() when there is no focus
                    ToggleEffects(true);
                    return Travel();
                case Action.Hostile:
                    if (eventFocus == null) return true; //flag event for destruction if attempting Follow() when there is no focus
                    ToggleEffects(true);
                    return Travel();
            }
            return false;
        }

        private void UpdateDistance()
        {
            //purpose: updates the difference is kilometres between the current and focus objects

            Vector3 difference = eventFocus.GetComponent<GeneralVariables>().GetPosition() - eventAssignee.GetComponent<GeneralVariables>().GetPosition(); //work out difference between both objects
            distanceFromFocus = difference.magnitude;
        }

        public void ToggleEffects(bool enabled)
        {
            //purposes: toggles particle and lens flare effect
            //parametres:
             //(enabled) toggle type
            
            if (objectsLensFlare != null) objectsLensFlare.GetComponent<LensFlare>().enabled = enabled;
            if (objectsParticles != null)
            {
                if (enabled && !objectsParticles.GetComponent<ParticleSystem>().isPlaying) objectsParticles.GetComponent<ParticleSystem>().Play();
                else if (!enabled && objectsParticles.GetComponent<ParticleSystem>().isPlaying) objectsParticles.GetComponent<ParticleSystem>().Stop();
            }
        }
        
        private bool Travel()
        {
            //purpose: directs object towards current focus

            //translate object
            Transform transform = eventAssignee.GetComponent<Transform>();
            GeneralVariables currentFocus = eventFocus.GetComponent<GeneralVariables>();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentFocus.GetPosition() - transform.position), maxRotate * Time.deltaTime);
            transform.position += transform.forward * maxSpeed * Time.deltaTime;

            //check if object has reached its destination
            if ((distanceFromFocus - (currentFocus.GetSize()) * 2) <= 0) return true; //flag event as complete due to reaching destination 
            else return false; //flag event as incomplete
        }
    };
}
