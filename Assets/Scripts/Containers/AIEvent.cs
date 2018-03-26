using UnityEngine;

/// <summary>
/// Emueration of possible actions the AI can perform
/// </summary>
public enum AIAction { Stationary, Travel, Hostile }

/// <summary>
/// Encapulsation for AI event data
/// </summary>
public class AIEvent : AIEventQueue
{
    /// <summary>
    /// Importance of this event
    /// </summary>
    private int eventPriority;

    /// <summary>
    /// Reference to the specific object this event is controlling
    /// </summary>
    private GameObject eventAssignee; 

    /// <summary>
    /// Reference to a possible focus this event should be considering
    /// </summary>
    private GameObject eventFocus;

    /// <summary>
    /// Enumerated action this event actually is
    /// </summary>
    private AIAction eventAIAction; //the action this event does

    /// <summary>
    /// How long this event should last
    /// </summary>
    private float eventDuration;

    /// <summary>
    /// Calculated magnitude of distance between eventAssignee and eventFocus
    /// </summary>
    private float distanceFromFocus;

    /// <summary>
    /// Local reference to lens flares attached to eventAssignee to be controlled by this event
    /// </summary>
    private GameObject[] objectsParticles;

    /// <summary>
    /// Local reference to particle systems attached to eventAssignee to be controlled by this event
    /// </summary>
    private GameObject[] objectsLensFlare;

    /// <summary>
    /// Speed limit for solar ship during travel
    /// </summary>
    private float maxSpeed;

    /// <summary>
    /// Maximum rotation percentage for solar ship turning travel
    /// </summary>
    private float maxRotate;

    public AIEvent(int priority, GameObject assignee, GameObject[] particles, GameObject[] lens, AIAction action, GameObject focus = null, float speed = 10f, float rotation = 0.1f, float duration = float.MaxValue)
    {
        eventPriority = priority;
        eventAssignee = assignee;
        eventFocus = focus;
        eventAIAction = action;
        eventDuration = duration;
        objectsParticles = particles;
        objectsLensFlare = lens;
        maxSpeed = speed;
        maxRotate = rotation;
        if (eventAIAction == AIAction.Hostile)
        {
            maxSpeed *= 20;
            maxRotate *= 20;
        }
        if (eventFocus != null) UpdateDistance();
    }

    /// <summary>
    /// Gets the event's priority
    /// </summary>
    /// <returns>Returns an integer that represents the importance of this event</returns>
    public int GetPriority() { return eventPriority; }

    /// <summary>
    /// Maintains the event and gets current status<para />
    /// Allows AIEvent to be used as a independent entity or ideally as a member of the AIEventQueue data structure
    /// </summary>
    /// <returns>Returns boolean status of event;
    /// true flags event as complete so that it can be destroyed and a new event enqueued
    /// and false flags event as incomplete and will require further polling to complete</returns>
    public override bool Poll()
    {
        //update event control variables
        eventDuration -= Time.deltaTime;
        if (eventDuration <= 0) return true; //flag event as complete due to exceeding duration
        if (eventFocus != null) UpdateDistance(); //update distance if a focus target exists

        switch (eventAIAction) //process event based on eventAIAction enum
        {
            case AIAction.Stationary:
                ToggleEffects(false);
                return false; //flag event as incomplete
            case AIAction.Travel:
                if (eventFocus == null) return true; //flag event for destruction if attempting Follow() when there is no focus
                ToggleEffects(true);
                return Travel();
            case AIAction.Hostile:
                if (eventFocus == null) return true; //flag event for destruction if attempting Follow() when there is no focus
                ToggleEffects(true);
                return Travel();
        }
        return false;
    }

    /// <summary>
    /// Updates the difference in kilometres between event's assignee and event's focus
    /// </summary>
    private void UpdateDistance()
    {
        Vector3 difference = eventFocus.GetComponent<GeneralObject>().GetPosition() - eventAssignee.GetComponent<GeneralObject>().GetPosition(); //work out difference between both objects
        distanceFromFocus = difference.magnitude;
    }

    /// <summary>
    /// Toggles both particle systems and lens flare effects
    /// </summary>
    /// <param name="enabled">Toggle type (true is on, false is off)</param>
    public void ToggleEffects(bool enabled)
    {
        if (objectsLensFlare != null) for (int i = 0; i < objectsLensFlare.Length; i++) objectsLensFlare[i].GetComponent<LensFlare>().enabled = enabled;
        if (objectsParticles != null)
        {
            for (int i = 0; i < objectsParticles.Length; i++)
            {
                if (enabled && !objectsParticles[i].GetComponent<ParticleSystem>().isPlaying) objectsParticles[i].GetComponent<ParticleSystem>().Play();
                else if (!enabled && objectsParticles[i].GetComponent<ParticleSystem>().isPlaying) objectsParticles[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    /// <summary>
    /// Directs the event assignee towards the event focus
    /// </summary>
    /// <returns>Returns as boolean where event assignee has reached its focus or not</returns>
    private bool Travel()
    {
        //translate object
        Transform transform = eventAssignee.GetComponent<Transform>();
        GeneralObject currentFocus = eventFocus.GetComponent<GeneralObject>();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentFocus.GetPosition() - transform.position), maxRotate * Time.deltaTime);
        transform.position += transform.forward * maxSpeed * Time.deltaTime;

        //check if object has reached its destination
        if ((distanceFromFocus - (currentFocus.GetSize()) * 2) <= 0) return true; //flag event as complete due to reaching destination 
        else return false; //flag event as incomplete
    }
};
